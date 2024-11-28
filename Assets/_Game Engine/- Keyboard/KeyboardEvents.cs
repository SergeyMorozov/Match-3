using System;

namespace GAME
{
    [Serializable]
    public class KeyboardEvents
    {
        public Action<ActionType> ActionStart;
        public Action<ActionType> ActionEnd;
    }
}
