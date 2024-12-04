using System;

namespace GAME
{
    [Serializable]
    public class GameSystemEvents
    {
        public Action GameInit;
        public Action GameStart;
        public Action GameReady;
        public Action GameOver;

        public Action GameMainMenuShow;
        public Action GameMainMenuHide;
        
        public Action<string> PlayerNameChange;

        public Action<ExtEvent> ExtEvent;
    }
    
    // События для устанвки их в инспекторе (например в настройках кнопок)
    public enum ExtEvent
    {
        None = 0,
        NewGame = 1,
        LeaderboardShow = 2,
        QuitGame = 3,
        Continue = 4
        
    }
}