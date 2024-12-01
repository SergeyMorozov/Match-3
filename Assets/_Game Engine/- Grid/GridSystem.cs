using UnityEngine;

namespace GAME
{
    public class GridSystem : MonoBehaviour
    {
        private static GridSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<GridSystem>();
        }

        public static GridSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new GridSystemSettings());
            }
        }

        public static GridSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new GridSystemData());
            }
        }

        public static GridSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new GridSystemEvents());
            }
        }

        [SerializeField] private GridSystemSettings settings;
        [SerializeField] private GridSystemData data;
        private GridSystemEvents events;

    }
}

