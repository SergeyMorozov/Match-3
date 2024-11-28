using System;

namespace GAME
{
    [Serializable]
    public class AppLoadingSystemEvents
    {
        public Action AppLoad;
        public Func<bool> AppLoadCheck;
        public Action AppLoadComplete;
    }
}
