using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class GameStoreLogicSaving : MonoBehaviour
    {
        private string _nameSaveData;
        private DataSave _dataSave;
        private bool _saving;
        
        private void Awake()
        {
            _dataSave = new DataSave { Key = new List<string>(), Value = new List<string>() };
            
            GameStoreSystem.Events.Save += StoreDataSave;
            GameStoreSystem.Events.AddObjectForSave += AddObjectForSave;
        }

        private void StoreDataSave()
        {
            if(_saving) return;
            
            _saving = true;
            _nameSaveData = GameStoreSystem.Data.StoreFileName;
            Debug.Log("[Save] ===>>> " + _nameSaveData);

            GameStoreSystem.Events.PrepareBlocksForSave?.Invoke();
        }

        private void AddObjectForSave(object dataObject)
        {
            string key = dataObject.GetType().Name;
            string json = JsonUtility.ToJson(dataObject);

            _dataSave.Key.Add(key);
            _dataSave.Value.Add(json);
            
            Debug.Log("[Save] object ( " + key + " )<br>" + json);
        }

        private void LateUpdate()
        {
            if (_dataSave.Key.Count == 0) return;

            string jsonData = JsonUtility.ToJson(_dataSave);
            GameStoreSystem.Events.RequestDataSave?.Invoke(_nameSaveData, jsonData);

            _dataSave.Key.Clear();
            _dataSave.Value.Clear();

            _saving = false;
        }
        
    }
}
