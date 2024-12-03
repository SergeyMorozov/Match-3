using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class LeaderboardSystemSettings : ScriptableObject
    {
        public string SaveFileName = "Leaderboard";
        public List<LeaderboardPlayer> DefaultListPlayers;
    }
}
