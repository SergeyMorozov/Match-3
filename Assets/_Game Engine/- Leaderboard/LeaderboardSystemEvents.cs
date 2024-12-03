using System;

namespace GAME
{
    [Serializable]
    public class LeaderboardSystemEvents
    {
        public Func<int, bool> CheckNewRecord;
        public Action<string, int> SetRecord;
        public Action ListPlayersChanged;
        public Func<string, int> GetScoreByPlayerName;
    }
}
