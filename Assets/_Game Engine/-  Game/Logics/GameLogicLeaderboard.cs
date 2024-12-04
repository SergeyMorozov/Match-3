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
            
            // Показываем UI списка рекордов
            LeaderboardCanvas.Instance.Show?.Invoke();
        }
        
        private void GameOverHide()
        {
            // Закрыли окно конца игры. Проверяем количество очков.
            int score = BoardSystem.Data.CurrentBoard.Score;
            string playerName = GameSystem.Data.PlayerName;

            // Есть ли игрок в списке
            if ((int)LeaderboardSystem.Events.GetScoreByPlayerName?.Invoke(playerName) > 0)
            {
                // Игрок есть в списке
                LeaderboardSystem.Events.SetRecord?.Invoke(GameSystem.Data.PlayerName, score);
                GameSystem.Events.GameMainMenuShow?.Invoke();
                return;
            }
            
            // Игрока ещё нет в списке. Есть ли рекорд?
            bool newRecord = (bool)LeaderboardSystem.Events.CheckNewRecord?.Invoke(score);
            
            if (!newRecord)
            {
                // Недостаточно очков, для записи в таблицу рекордов
                GameSystem.Events.GameMainMenuShow?.Invoke();
            }
            else
            {
                // Запись в таблицу
                if (GameSystem.Data.PlayerName == "")
                {
                    // Пустое имя. Ввод имени
                    PlayerNameCanvas.Instance.Show?.Invoke();
                }
                else
                {
                    // Добавить новую запись
                    LeaderboardSystem.Events.SetRecord?.Invoke(GameSystem.Data.PlayerName, score);
                }
            }
        }

        private void PlayerNameChange(string playerName)
        {
            GameSystem.Data.PlayerName = playerName;
            LeaderboardSystem.Events.SetRecord?.Invoke(playerName, BoardSystem.Data.CurrentBoard.Score);
        }

    }
}

