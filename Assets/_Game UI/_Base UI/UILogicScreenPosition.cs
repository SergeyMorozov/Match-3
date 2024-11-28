using UnityEngine;

namespace  GAME
{
    public class UILogicScreenPosition : MonoBehaviour
    {
        private RectTransform _canvas;
        private Camera _camera;
        private Camera _cameraUI;

        private void Awake()
        {
            _canvas = UISystem.Data.MainCanvas;
            _cameraUI = UISystem.Data.CameraUI;
            _camera = Camera.main;
            
            UISystem.Events.GetScreenFromWorld += GetScreenFromWorld;
        }

        private Vector3 GetScreenFromWorld(Vector3 worldPosition)
        {
            Vector3 screenPoint = _camera.WorldToScreenPoint(worldPosition);
            screenPoint.z = 0;
            Vector2 anchoredPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas, screenPoint, _cameraUI, out anchoredPos);
            return anchoredPos;
        }

    }
}

