using UnityEngine;

namespace GAME
{
    public class GameStoreSystem : MonoBehaviour
    {
        private static GameStoreSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<GameStoreSystem>();
        }
        
        public static GameStoreSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance._settings ?? (Instance._settings = new GameStoreSettings());
            }
        }
        
        public static GameStoreData Data
        {
            get
            {
                CheckInstance();
                return Instance._data ?? (Instance._data = new GameStoreData());
            }
        }

        public static GameStoreEvents Events
        {
            get
            {
                CheckInstance();
                return Instance._events ?? (Instance._events = new GameStoreEvents());
            }
        }
        
        [SerializeField] private GameStoreSettings _settings;
        [SerializeField] private GameStoreData _data;
        private GameStoreEvents _events;
    }

}
