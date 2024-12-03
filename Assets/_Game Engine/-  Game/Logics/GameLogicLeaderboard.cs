using System.Linq;
using UnityEngine;

namespace  GAME
{
    public class GameLogicLeaderboard : MonoBehaviour
    {
        private void Awake()
        {
            GameSystem.Events.ExtEvent += ExtEvent;
            GameOverCanvas.Instance.Hide += GameOverHide;
            GameSystem.Events.PlayerNameChange += PlayerNameChange;
        }

        private void ExtEvent(ExtEvent extEvent)
        {
            if(extEvent != GAME.ExtEvent.LeaderboardShow) return;
            
            LeaderboardCanvas.Instance.Show?.Invoke();
        }
        
        private void GameOverHide()
        {
            int score = BoardSystem.Data.CurrentBoard.Score;
            bool newRecord = (bool)LeaderboardSystem.Events.CheckNewRecord?.Invoke(score);
            
            if (!newRecord)
            {
                GameSystem.Events.GameMainMenuShow?.Invoke();
            }
            else
            {
                if (GameSystem.Data.PlayerName == "")
                {
                    PlayerNameCanvas.Instance.Show?.Invoke();
                }
                else
                {
                    LeaderboardSystem.Events.SetNewRecord?.Invoke(GameSystem.Data.PlayerName, score);
                }
            }
        }

        private void PlayerNameChange(string playerName)
        {
            GameSystem.Data.PlayerName = playerName;
            LeaderboardSystem.Events.SetNewRecord?.Invoke(playerName, BoardSystem.Data.CurrentBoard.Score);
        }

        /*
        private void SetNewRecord()
        {
            LeaderboardPlayer player =
                LeaderboardSystem.Data.ListPlayers.Find(p => p.PlayerName == GameSystem.Data.PlayerName);

            if (player == null)
            {
                player = new LeaderboardPlayer { PlayerName = GameSystem.Data.PlayerName };
                LeaderboardSystem.Data.ListPlayers.Add(player);
            }

            player.Score = BoardSystem.Data.CurrentBoard.Score;

            LeaderboardCanvas.Instance.Show?.Invoke();
        }
        */

    }
}

