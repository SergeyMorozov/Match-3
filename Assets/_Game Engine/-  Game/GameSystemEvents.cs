using System;

namespace GAME
{
    [Serializable]
    public class GameSystemEvents
    {
        public Action<Action, Action> GameActionWithFade;
        
        public Action GameMainMenuShow;
        public Action GameMainMenuHide;
        public Action GameFadeComplete;
        public Action GameInit;
        public Action GameStart;
        public Action GameReady;
    }
}