using System;

namespace GAME
{
    [Serializable]
    public class LeaderboardSystemEvents
    {
        public Func<int, bool> CheckNewRecord;
        public Action<string, int> SetNewRecord;
    }
}
