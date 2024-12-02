using UnityEngine;

namespace  GAME
{
    public class MainMenuController : MonoBehaviour
    {
        private MainMenuView _view;
        private bool _show;

        private void Awake()
        {
            _view = MainMenuCanvas.Instance.View;
            _view.gameObject.SetActive(false);

            _view.ButtonView.transform.SetParent(_view.Content.parent);
            _view.ButtonView.gameObject.SetActive(false);

            Init();
            
            MainMenuCanvas.Instance.Show += Show;
            MainMenuCanvas.Instance.Hide += Hide;
            
            GameSystem.Events.GameMainMenuShow += Show;
            GameSystem.Events.GameMainMenuHide += Hide;
        }

        private void Init()
        {
            Tools.RemoveObjects(_view.Content);
            foreach (ButtonPreset buttonPreset in _view.Buttons)
            {
                ButtonView buttonView = Tools.AddUI<ButtonView>(_view.ButtonView, _view.Content);
                buttonView.ButtonPreset = buttonPreset;
                buttonView.Label.text = buttonPreset.Text;
                buttonView.Button.onClick.AddListener(delegate { SelectMenu(buttonPreset.extEvent); });
            }
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

        private void SelectMenu(ExtEvent extEvent)
        {
            Debug.Log("EventExt " + extEvent);
            GameSystem.Events.ExtEvent?.Invoke(extEvent);
        }


    }
}


