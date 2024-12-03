using UnityEngine;

namespace  GAME
{
    public class GameLogic : MonoBehaviour
    {
        private void Awake()
        {
            GameSystem.Events.GameMainMenuShow += StopGame;
            GameSystem.Events.GameMainMenuHide += StartGame;
            GameSystem.Events.GameOver += GameOver;
        }

        private void StartGame()
        {
            GameSystem.Data.GamePause = false;
            GameSystem.Data.GamePlaying = true;
        }

        private void StopGame()
        {
            GameSystem.Data.GamePause = true;
        }

        private void GameOver()
        {
            GameSystem.Data.GamePause = true;
            GameSystem.Data.GamePlaying = false;
        }

    }
}

