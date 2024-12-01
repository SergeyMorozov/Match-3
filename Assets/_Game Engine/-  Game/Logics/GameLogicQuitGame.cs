using UnityEngine;

namespace  GAME
{
    public class GameLogicQuitGame : MonoBehaviour
    {
        private void Awake()
        {
            GameSystem.Events.ExtEvent += ExtEvent;
        }

        private void ExtEvent(ExtEvent extEvent)
        {
            if(extEvent != GAME.ExtEvent.QuitGame) return;
                        
            Application.Quit();
        }
    }
}

