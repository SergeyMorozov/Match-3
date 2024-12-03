using UnityEngine;

namespace  GAME
{
    public class BoardController : MonoBehaviour
    {
        private BoardView _view;
        private bool _show;

        private BoardObject _board;
        
        private void Awake()
        {
            _view = BoardCanvas.Instance.View;
            _view.gameObject.SetActive(false);
            _view.ButtonHome.onClick.AddListener(GoMainMenu);

            GameSystem.Events.GameStart += Show;
            BoardSystem.Events.ScoreChanged += ScoreChanged;
        }

        private void GoMainMenu()
        {
            GameSystem.Events.GameMainMenuShow?.Invoke();
        }

        private void ScoreChanged(BoardObject board)
        {
            _board = board;
            _view.PanelMoney.Label.text = _board.Money.ToString();
            _view.PanelMoney.LabelChange.text = _board.MoneyChange > 0 ? "+" : "";
            _view.PanelMoney.LabelChange.text += _board.MoneyChange.ToString();
            _view.PanelScore.Label.text = _board.Score.ToString();
            _view.PanelScore.LabelChange.text = "+" + _board.ScoreChange;
            _view.PanelCost.Label.text = "-" + _board.Cost;
            _view.PanelCost.LabelChange.text = "";
        }

        private void Show()
        {
            if(_show) return;
            _show = true;
            _view.gameObject.SetActive(true);
        }

        private void Hide()
        {
            if(!_show) return;
            _show = false;
            _view.gameObject.SetActive(false);
        }

    }
}


