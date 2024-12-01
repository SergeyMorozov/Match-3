using UnityEngine;

namespace  GAME
{
    public class GameLogicLeaderboard : MonoBehaviour
    {
        private void Awake()
        {
            GameSystem.Events.ExtEvent += ExtEvent;
        }

        private void ExtEvent(ExtEvent extEvent)
        {
            if(extEvent != GAME.ExtEvent.LeaderboardShow) return;
            
            
        }
    }
}

