using UnityEngine;

namespace  GAME
{
    public class GameLogicNewGame : MonoBehaviour
    {
        private void Awake()
        {
            GameSystem.Events.ExtEvent += ExtEvent;
            GameSystem.Events.GameMainMenuShow += GameMainMenuShow;
            GameSystem.Events.GameMainMenuHide += GameMainMenuHide;
        }

        private void ExtEvent(ExtEvent extEvent)
        {
            if (extEvent == GAME.ExtEvent.NewGame)
            {
                GameSystem.Events.GameMainMenuHide?.Invoke();

                BoardPreset boardPreset = Tools.GetRandomObject(BoardSystem.Settings.Boards);
                BoardSystem.Events.BoardCreate?.Invoke(boardPreset);

                GameSystem.Events.GameStart?.Invoke();
            }
            
            if (extEvent == GAME.ExtEvent.Continue)
            {
                GameSystem.Events.GameMainMenuHide?.Invoke();
            }
        }
        
        private void GameMainMenuShow()
        {
            GameSystem.Data.GamePause = true;
            GameSystem.Data.GamePlaying = false;
        }

        private void GameMainMenuHide()
        {
            GameSystem.Data.GamePause = false;
            GameSystem.Data.GamePlaying = true;
        }


    }
}

