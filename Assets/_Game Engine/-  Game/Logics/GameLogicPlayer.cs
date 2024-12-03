using UnityEngine;

namespace  GAME
{
    public class GameLogicPlayer : MonoBehaviour
    {
        private void Awake()
        {
            GameSystem.Events.GameInit += GameInit;
        }

        private void GameInit()
        {
            GameSystem.Data.PlayerName = PlayerPrefs.GetString("player_name", "");
        }

    }
}

