using UnityEngine;

namespace GAME
{
    public class AppLoadingSystem : MonoBehaviour
    {
        private static AppLoadingSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<AppLoadingSystem>();
        }

        public static AppLoadingSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new AppLoadingSystemSettings());
            }
        }

        public static AppLoadingSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new AppLoadingSystemData());
            }
        }

        public static AppLoadingSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new AppLoadingSystemEvents());
            }
        }

        [SerializeField] private AppLoadingSystemSettings settings;
        [SerializeField] private AppLoadingSystemData data;
        private AppLoadingSystemEvents events;

    }
}

