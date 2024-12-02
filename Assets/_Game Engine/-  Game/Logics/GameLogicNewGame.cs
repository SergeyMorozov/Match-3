using UnityEngine;

namespace  GAME
{
    public class GameLogicNewGame : MonoBehaviour
    {
        private void Awake()
        {
            GameSystem.Events.ExtEvent += ExtEvent;
        }

        private void ExtEvent(ExtEvent extEvent)
        {
            if(extEvent != GAME.ExtEvent.NewGame) return;
            
            GameSystem.Events.GameMainMenuHide?.Invoke();

            BoardPreset boardPreset = Tools.GetRandomObject(BoardSystem.Settings.Boards);
            BoardSystem.Events.BoardCreate?.Invoke(boardPreset);
            
            GameSystem.Events.GameStart?.Invoke();
        }
    }
}

