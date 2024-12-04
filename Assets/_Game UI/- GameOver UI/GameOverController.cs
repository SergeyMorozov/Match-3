using UnityEngine;

namespace  GAME
{
    public class GameOverController : MonoBehaviour
    {
        private GameOverView _view;
        private bool _show;

        private void Awake()
        {
            _view = GameOverCanvas.Instance.View;
            _view.gameObject.SetActive(false);
            
            _view.ButtonClose.onClick.AddListener(ButtonClose);

            GameOverCanvas.Instance.Show += Show;
            GameOverCanvas.Instance.Hide += Hide;
            
            GameSystem.Events.GameOver += Show;
        }

        private void Show()
        {
            if(_show) return;
            _show = true;
            _view.gameObject.SetActive(true);

            _view.LabelScore.text = BoardSystem.Data.CurrentBoard.Score.ToString();
        }

        private void Hide()
        {
            if(!_show) return;
            _show = false;
            _view.gameObject.SetActive(false);
        }

        private void ButtonClose()
        {
            GameOverCanvas.Instance.Hide?.Invoke();
        }

    }
}


