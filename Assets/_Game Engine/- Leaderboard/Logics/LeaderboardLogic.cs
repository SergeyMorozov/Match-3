using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class LeaderboardLogic : MonoBehaviour
    {
        private List<LeaderboardData> _listData;

        private void Awake()
        {
            GameSystem.Events.GameInit += GameInit;
        }

        private void GameInit()
        {
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            PlayerPrefs.SetString("leaderboard", "");
            
            string json = PlayerPrefs.GetString("leaderboard", "");

            if (json == "")
            {
                CreateDefaultList();
                SaveLeaderboard();
            }
            else
            {
                LeaderboardSystem.Data.ListPlayers = JsonUtility.FromJson<LeaderboardStore>(json).ListPlayers;
            }
        }

        private void SaveLeaderboard()
        {
            LeaderboardStore store = new LeaderboardStore { ListPlayers = LeaderboardSystem.Data.ListPlayers };
            string json = JsonUtility.ToJson(store);
            PlayerPrefs.SetString("leaderboard", json);
        }

        private void CreateDefaultList()
        {
            LeaderboardSystem.Data.ListPlayers = new List<LeaderboardData>();
            foreach (LeaderboardData playerData in LeaderboardSystem.Settings.DefaultListPlayers)
            {
                LeaderboardData leaderboardData = new LeaderboardData
                {
                    PlayerName = playerData.PlayerName,
                    Score = playerData.Score
                };
                    
                LeaderboardSystem.Data.ListPlayers.Add(leaderboardData);
            }
        }
    }
}

