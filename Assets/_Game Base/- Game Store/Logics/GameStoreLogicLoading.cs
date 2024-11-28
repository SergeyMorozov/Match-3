using UnityEngine;

namespace GAME
{
    public class GameStoreLogicLoading : MonoBehaviour
    {
        private void Awake()
        {
            GameStoreSystem.Events.Load += StoreDataLoad;
        }

        private void StoreDataLoad(string nameSaveData)
        {
            Debug.Log("[Load] <<<=== " + nameSaveData);
            
            if (nameSaveData == "")
            {
                // No loading
                GameStoreSystem.Events.LoadComplete?.Invoke();
            }
            else
            {
                // Load from save
                GameStoreSystem.Events.RequestDataLoad?.Invoke(nameSaveData);
            }
        }
    }
}
