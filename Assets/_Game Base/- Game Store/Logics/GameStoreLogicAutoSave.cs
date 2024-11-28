using UnityEngine;

namespace GAME
{
    public class GameStoreLogicAutoSave : MonoBehaviour
    {
        private float _time;

        private void Awake()
        {
            GameStoreSystem.Events.SaveComplete += SaveComplete;
        }

        private void SaveComplete()
        {
            _time = 0;
        }

        private void Update()
        {
            if (!GameSystem.Data.GamePlaying) return;

            _time += Time.deltaTime;
            if (_time < GameStoreSystem.Settings.AutoSaveTime) return;

            _time = 0;
            
#if UNITY_WEBGL
            GameStoreSystem.Events.Save?.Invoke();
#endif
        }
    }
}
