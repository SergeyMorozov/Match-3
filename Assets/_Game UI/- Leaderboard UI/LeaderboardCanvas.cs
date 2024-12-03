using System;
using UnityEngine;

namespace GAME
{
    public class LeaderboardCanvas : MonoBehaviour
    {
        private static LeaderboardCanvas _instance;

        public static LeaderboardCanvas Instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<LeaderboardCanvas>();
                return _instance;
            }
        }

        // Events
        public Action Show;
        public Action Hide;
        
        // Views
        public LeaderboardView View;
    }
}

