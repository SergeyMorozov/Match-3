using UnityEngine;

namespace GAME
{
    public class GemSystem : MonoBehaviour
    {
        private static GemSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<GemSystem>();
        }

        public static GemSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new GemSystemSettings());
            }
        }

        public static GemSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new GemSystemData());
            }
        }

        public static GemSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new GemSystemEvents());
            }
        }

        [SerializeField] private GemSystemSettings settings;
        [SerializeField] private GemSystemData data;
        private GemSystemEvents events;

    }
}

