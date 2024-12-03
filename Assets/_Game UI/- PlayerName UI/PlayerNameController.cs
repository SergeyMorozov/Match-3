using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class PlayerNameController : MonoBehaviour
    {
        private PlayerNameView _view;
        private bool _show;

        private void Awake()
        {
            _view = PlayerNameCanvas.Instance.View;
            _view.gameObject.SetActive(false);
            _view.InputField.onValueChanged.AddListener(EnterNameChanged);
            _view.Button.onClick.AddListener(EnterName);
            
            _view.Button.interactable = _view.InputField.text.Length >= _view.MinNumberChar;

            PlayerNameCanvas.Instance.Show += Show;
            PlayerNameCanvas.Instance.Hide += Hide;
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

        private void EnterNameChanged(string text)
        {
            _view.Button.interactable = text.Length >= _view.MinNumberChar;
        }
        
        private void EnterName()
        {
            GameSystem.Events.PlayerNameChange?.Invoke(_view.InputField.text);
            PlayerNameCanvas.Instance.Hide?.Invoke();
        }

    }
}


