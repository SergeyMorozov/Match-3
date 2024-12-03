using UnityEngine;

namespace GAME
{
    public class StoreSystem : MonoBehaviour
    {
        private static StoreSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<StoreSystem>();
        }

        public static StoreSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new StoreSystemSettings());
            }
        }

        public static StoreSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new StoreSystemData());
            }
        }

        public static StoreSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new StoreSystemEvents());
            }
        }

        [SerializeField] private StoreSystemSettings settings;
        [SerializeField] private StoreSystemData data;
        private StoreSystemEvents events;

    }
}

