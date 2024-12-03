using System;

namespace GAME
{
    [Serializable]
    public class StoreSystemEvents
    {
        public Action<string, string> Save;
        public Func<string, string> Load;
    }
}
