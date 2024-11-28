using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace  GAME
{
    public class UILogicEsc : MonoBehaviour
    {
        private void Awake()
        {
            UISystem.Data.OpenedViews = new List<Action>();
            
            KeyboardSystem.Events.ActionStart += ActionStart;
            KeyboardSystem.Events.ActionEnd += ActionEnd;
            UISystem.Events.RegHide += RegHide;
            UISystem.Events.RemoveHide += RemoveHide;
            UISystem.Events.HideAll += HideAll;
        }

        private void RegHide(Action action)
        {
            UISystem.Data.OpenedViews.Add(action);
            UISystem.Data.OpenViewsCounter = UISystem.Data.OpenedViews.Count;
        }

        private void RemoveHide(Action action)
        {
            UISystem.Data.OpenedViews.Remove(action);
            UISystem.Data.OpenViewsCounter = UISystem.Data.OpenedViews.Count;
        }

        private void HideAll()
        {
            int count = UISystem.Data.OpenedViews.Count;
            for (var i = 0; i < count; i++)
            {
                var actionHide = UISystem.Data.OpenedViews[0];
                actionHide?.Invoke();
            }

            UISystem.Data.OpenedViews.Clear();
            UISystem.Data.OpenViewsCounter = 0;
        }

        private void ActionStart(ActionType action)
        {
            if (action != ActionType.Esc) return;
            
            if (UISystem.Data.OpenedViews.Count > 0)
            {
                HideLastUI();
            }
            else
            {
                if (!UISystem.Data.IsEscDisable) GameSystem.Events.GameMainMenuShow?.Invoke();
            }

            UISystem.Data.IsEscDisable = false;
        }

        private void ActionEnd(ActionType action)
        {
            // if (action == ActionType.Esc) UISystem.Data.EscBusy = false;
        }

        private void HideLastUI()
        {
            Action action = UISystem.Data.OpenedViews.Last();
            action?.Invoke();
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(1))
            {
                if(UISystem.Data.OpenedViews.Count > 0) HideLastUI();
            }
        }
    }
}

