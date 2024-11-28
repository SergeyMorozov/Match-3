using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace  GAME
{
    public class UILogic : MonoBehaviour
    {
        public static bool IsOverUI => _isOverUI();
        private static bool _isOverUI()
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);

#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR

		foreach (Touch touch in Input.touches)
		{
			pointerData.position = touch.position;
			if(CheckCanvas(pointerData))
			return true;
		}
		return false;

#endif

            pointerData.position = Input.mousePosition;
            return CheckCanvas(pointerData);
        }

        static bool CheckCanvas(PointerEventData pointerData)
        {
            if (EventSystem.current == null)
                return false;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i].gameObject.GetComponent<CanvasRenderer>())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void Awake()
        {
            UISystem.Data.CameraUI.gameObject.SetActive(false);
        }
    }
}

