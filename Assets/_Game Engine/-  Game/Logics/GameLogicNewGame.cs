using UnityEngine;

namespace  GAME
{
    public class GameLogicNewGame : MonoBehaviour
    {
        private int _indexBoards;
        
        private void Awake()
        {
            GameSystem.Events.ExtEvent += ExtEvent;
        }

        private void ExtEvent(ExtEvent extEvent)
        {
            if (extEvent == GAME.ExtEvent.NewGame)
            {
                GameSystem.Events.GameMainMenuHide?.Invoke();

                if (_indexBoards >= BoardSystem.Settings.Boards.Count) _indexBoards = 0;
                BoardPreset boardPreset = BoardSystem.Settings.Boards[_indexBoards];
                _indexBoards++;
                
                BoardSystem.Events.BoardCreate?.Invoke(boardPreset);
                GameSystem.Events.GameStart?.Invoke();
            }
            
            if (extEvent == GAME.ExtEvent.Continue)
            {
                GameSystem.Events.GameMainMenuHide?.Invoke();
            }
        }
        
    }
}

