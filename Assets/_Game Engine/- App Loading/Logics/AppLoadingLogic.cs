using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using YG;

namespace  GAME
{
    public class AppLoadingLogic : MonoBehaviour
    {
        private AppLoadingSystemData _data;
        private bool _isLoadingComplete;
        private Func<bool> _actionCheck;
        private Action _actionComplete;
        private bool _useFade;
        private bool _noClose;
        private bool _nextStep;

        private void Awake()
        {
            _data = AppLoadingSystem.Data;
            
            AppLoadingSystem.Events.AppLoad += AppLoad;
            GameStoreSystem.Events.SettingLoaded += NextStep;
            GameStoreSystem.Events.LoadComplete += NextStep;
        }

        private void AppLoad()
        {
            StartCoroutine(TimeLineLoading());
        }

        IEnumerator TimeLineLoading()
        {
            _data.IsActive = true;
            _data.ShowUI = true;
            _useFade = true;

            _data.Value = 0;
            _data.ValueStep = 0;
            
            // Settings
            _nextStep = false;
            
            Debug.Log("[Loading] Settings");
            GameStoreSystem.Events.RequestSettings?.Invoke();
            yield return new WaitUntil(() => _nextStep);
            
            // Loading last save
            _data.ValueStep = 0.3f;
            _nextStep = false;
            string nameSaveData = PlayerPrefs.GetString("last_save", "");
            if (nameSaveData == "Save 1") nameSaveData = "";
            GameStoreSystem.Data.StoreFileName = nameSaveData;
            
            Debug.Log("[Loading] Last save (" + nameSaveData + ")");
            GameStoreSystem.Events.Load?.Invoke(nameSaveData);
            yield return new WaitUntil(() => _nextStep);
            
            // World init
            _data.ValueStep = 0.6f;
            _nextStep = false;
            
            Debug.Log("[Loading] World init");
            yield return new WaitUntil(() => _nextStep);
            
            // Load complete
            _data.ValueStep = 1f;
            _nextStep = false;
        }

        private void NextStep()
        {
            _nextStep = true;
        }

        private void Update()
        {
            if (!_data.IsActive || !_data.ShowUI || _data.Value >= 1) return;

            _data.Value += Time.deltaTime / AppLoadingSystem.Settings.FakeTimeLoading;

            if (_data.Value < _data.ValueStep) return;
            _data.Value = _data.ValueStep;

            if (_data.Value >= 1)
                GameSystem.Events.GameActionWithFade?.Invoke(Close, GameSystem.Events.GameMainMenuShow);
        }

        private void Close()
        {
            _data.IsActive = false;
            _data.ShowUI = false;
        }
        
    }
}

