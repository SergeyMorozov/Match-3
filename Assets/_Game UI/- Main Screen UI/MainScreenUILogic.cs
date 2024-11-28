using UnityEngine;

namespace  GAME
{
    public class MainScreenUILogic : MonoBehaviour
    {
        private MainScreenView _view;
        private bool _show;

        private void Awake()
        {
            _view = MainScreenCanvas.Instance.View;
            _view.gameObject.SetActive(false);

            MainScreenCanvas.Instance.Show += Show;
            MainScreenCanvas.Instance.Hide += Hide;
            
            GameSystem.Events.GameMainMenuShow += GameMainMenuShow;
        }

        private void GameMainMenuShow()
        {
            Show();
        }

        private void Show()
        {
            if(_show)
            {
                Hide();
                return;
            }
            
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


