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
            
            Application.Quit();
        }
    }
}

