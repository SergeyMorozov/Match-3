using UnityEngine;

namespace  GAME
{
    public class GameLogicPlayer : MonoBehaviour
    {
        private void Awake()
        {
            GameSystem.Events.GameInit += GameInit;
            GameSystem.Events.PlayerNameChange += PlayerNameChange;
        }

        private void GameInit()
        {
            GameSystem.Data.PlayerName = PlayerPrefs.GetString("player_name", "");
        }
        
        private void PlayerNameChange(string playerName)
        {
            GameSystem.Data.PlayerName = playerName;
            PlayerPrefs.SetString("player_name", playerName);
        }

    }
}

