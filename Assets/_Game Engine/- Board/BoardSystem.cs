using UnityEngine;

namespace GAME
{
    public class BoardSystem : MonoBehaviour
    {
        private static BoardSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<BoardSystem>();
        }

        public static BoardSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new BoardSystemSettings());
            }
        }

        public static BoardSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new BoardSystemData());
            }
        }

        public static BoardSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new BoardSystemEvents());
            }
        }

        [SerializeField] private BoardSystemSettings settings;
        [SerializeField] private BoardSystemData data;
        private BoardSystemEvents events;

    }
}

