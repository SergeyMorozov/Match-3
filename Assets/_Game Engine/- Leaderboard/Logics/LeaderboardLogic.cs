using System.Linq;
using UnityEngine;

namespace  GAME
{
    public class LeaderboardLogic : MonoBehaviour
    {
        private void Awake()
        {
            LeaderboardSystem.Events.CheckNewRecord += CheckNewRecord;
            LeaderboardSystem.Events.SetRecord += SetRecord;
            LeaderboardSystem.Events.GetScoreByPlayerName += GetScoreByPlayerName;
        }

        private bool CheckNewRecord(int score)
        {
            int minScore = LeaderboardSystem.Data.ListPlayers.Last().Score;
            return score > minScore;
        }

        private void SetRecord(string playerName, int score)
        {
            LeaderboardPlayer player =
                LeaderboardSystem.Data.ListPlayers.Find(p => p.PlayerName == playerName);

            if (player == null)
            {
                player = new LeaderboardPlayer { PlayerName = playerName };
                LeaderboardSystem.Data.ListPlayers.Add(player);
            }

            if(score < player.Score) return;
            
            player.Score = score;
            
            LeaderboardSystem.Data.ListPlayers.Sort(SortList);
            LeaderboardSystem.Events.ListPlayersChanged?.Invoke();
        }

        private int SortList(LeaderboardPlayer player1, LeaderboardPlayer player2)
        {
            if (player1.Score < player2.Score) return 1;
            if (player1.Score > player2.Score) return -1;
            return 0;
        }

        private int GetScoreByPlayerName(string playerName)
        {
            LeaderboardPlayer player = LeaderboardSystem.Data.ListPlayers.Find(p => p.PlayerName == playerName);
            return player?.Score ?? 0;
        }

    }
}

