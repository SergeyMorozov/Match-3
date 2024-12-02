using System;

namespace GAME
{
    [Serializable]
    public class BoardSystemEvents
    {
        public Action<BoardPreset> BoardCreate;
    }
}
