using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class LeaderboardController : MonoBehaviour
    {
        private LeaderboardView _view;
        private bool _show;

        private void Awake()
        {
            _view = LeaderboardCanvas.Instance.View;
            _view.gameObject.SetActive(false);
            
            _view.ButtonClose.onClick.AddListener(ButtonClose);
            _view.Prefab.transform.SetParent(_view.Content.parent);
            _view.Prefab.gameObject.SetActive(false);

            LeaderboardCanvas.Instance.Show += Show;
            LeaderboardCanvas.Instance.Hide += Hide;
            
            LeaderboardSystem.Events.ListPlayersChanged += Show;
        }

        private void Show()
        {
            if(_show) return;
            _show = true;
            _view.gameObject.SetActive(true);

            int countPlayers = Mathf.Min(_view.MaxNumberPlayers, LeaderboardSystem.Data.ListPlayers.Count); 
            
            Tools.RemoveObjects(_view.Content);
            for (var i = 0; i < countPlayers; i++)
            {
                var player = LeaderboardSystem.Data.ListPlayers[i];
                LeaderboardInfo info = Tools.AddUI<LeaderboardInfo>(_view.Prefab, _view.Content);
                info.LabelNumber.text = (i + 1).ToString();
                info.LabelName.text = player.PlayerName;
                info.LabelScore.text = player.Score.ToString();
            }
        }

        private void Hide()
        {
            if(!_show) return;
            _show = false;
            _view.gameObject.SetActive(false);
        }

        private void ButtonClose()
        {
            LeaderboardCanvas.Instance.Hide?.Invoke();
            GameSystem.Events.GameMainMenuShow?.Invoke();
        }

    }
}


