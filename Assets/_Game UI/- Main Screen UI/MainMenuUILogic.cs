using UnityEngine;

namespace  GAME
{
    public class MainMenuUILogic : MonoBehaviour
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
            
            GameSystem.Events.GameMainMenuShow += GameMainMenuShow;
        }

        private void Init()
        {
            Tools.RemoveObjects(_view.Content);
            for (var i = 0; i < _view.ButtonNames.Count; i++)
            {
                var buttonName = _view.ButtonNames[i];
                ButtonView buttonView = Tools.AddUI<ButtonView>(_view.ButtonView, _view.Content);
                buttonView.Label.text = buttonName;
                buttonView.Button.onClick.AddListener(delegate { SelectMenu(buttonView); });
                buttonView.Index = i;
            }
        }
        
        private void GameMainMenuShow()
        {
            Show();
        }

        private void Show()
        {
            if(_show) return;
            _show = true;
            _view.gameObject.SetActive(true);
        }

        private void SelectMenu(ButtonView buttonView)
        {
            switch (buttonView.Index)
            {
                
            }
        }

        private void Hide()
        {
            if(!_show) return;
            _show = false;
            _view.gameObject.SetActive(false);
        }


    }
}


