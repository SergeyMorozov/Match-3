using System;
using UnityEngine;
//using YG;

namespace  GAME
{
    public class GameLogicYG : MonoBehaviour
    {
        // private YandexGame _yandexGame;
        
        private void Awake()
        {
            // _yandexGame = FindAnyObjectByType<YandexGame>();
            
            // LevelSystem.Events.LevelNext += FullscreenShow;
            // LevelSystem.Events.LevelRestart += FullscreenShow;
            // LevelSystem.Events.LevelContinueAd += RewardedShow;
            
            // YandexGame.RewardVideoEvent += Reward;
            
            // LevelSystem.Events.LevelComplete += LevelComplete;
        }

        private void FullscreenShow()
        {
            // _yandexGame._FullscreenShow();
        }
        
        private void RewardedShow()
        {
            // _yandexGame._RewardedShow(0);
        }

        private void Reward(int id)
        {
            if (id == 0)
            {
                // LevelSystem.Events.LevelContinue?.Invoke();
            }
        }

        private void LevelComplete(int obj)
        {
            // YandexGame.savesData.Money = (int)PlayerSystem.Data.CurrentPlayer.Money;
            // YandexGame.savesData.LevelNumber = LevelSystem.Data.LevelNumber + 1;
            // YandexGame.SaveProgress();
            // YandexGame.NewLeaderboardScores("lbLevels", LevelSystem.Data.LevelNumber);
        }

    }
}

