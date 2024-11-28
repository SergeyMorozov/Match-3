using UnityEngine;

namespace GAME
{
    public class KeyboardSystem : MonoBehaviour
    {
        private static KeyboardSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<KeyboardSystem>();
        }

        public static KeyboardSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new KeyboardSettings());
            }
        }

        public static KeyboardData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new KeyboardData());
            }
        }

        public static KeyboardEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new KeyboardEvents());
            }
        }

        [SerializeField] private KeyboardSettings settings;
        [SerializeField] private KeyboardData data;
        private KeyboardEvents events;

    }
}

