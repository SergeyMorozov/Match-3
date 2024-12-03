using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class LeaderboardLogicLoadSave : MonoBehaviour
    {
        private List<LeaderboardPlayer> _listData;

        private void Awake()
        {
            GameSystem.Events.GameInit += GameInit;
            LeaderboardSystem.Events.ListPlayersChanged += ListPlayersChanged;
        }

        private void GameInit()
        {
            LoadLeaderboard();
        }

        private void ListPlayersChanged()
        {
            SaveLeaderboard();
        }

        private void LoadLeaderboard()
        {
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
            LeaderboardSystem.Data.ListPlayers = new List<LeaderboardPlayer>();
            foreach (LeaderboardPlayer playerData in LeaderboardSystem.Settings.DefaultListPlayers)
            {
                LeaderboardPlayer leaderboardPlayer = new LeaderboardPlayer
                {
                    PlayerName = playerData.PlayerName,
                    Score = playerData.Score
                };
                    
                LeaderboardSystem.Data.ListPlayers.Add(leaderboardPlayer);
            }
        }
    }
}

