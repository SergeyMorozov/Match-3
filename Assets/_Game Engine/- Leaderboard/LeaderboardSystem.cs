using UnityEngine;

namespace GAME
{
    public class LeaderboardSystem : MonoBehaviour
    {
        private static LeaderboardSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<LeaderboardSystem>();
        }

        public static LeaderboardSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new LeaderboardSystemSettings());
            }
        }

        public static LeaderboardSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new LeaderboardSystemData());
            }
        }

        public static LeaderboardSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new LeaderboardSystemEvents());
            }
        }

        [SerializeField] private LeaderboardSystemSettings settings;
        [SerializeField] private LeaderboardSystemData data;
        private LeaderboardSystemEvents events;

    }
}

