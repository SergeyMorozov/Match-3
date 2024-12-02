using System;
using UnityEngine;

namespace  GAME
{
    public class BoardLogicSelectCell : MonoBehaviour
    {
        private Camera _camera;
        private Plane _plane;

        private float _cellSize;
        private float _offsetX;
        private float _offsetY;
        
        private void Awake()
        {
            _camera = Camera.main;
            _plane = new Plane(Vector3.back, Vector3.zero);
            
            BoardSystem.Events.BoardCreate += BoardCreate;
        }

        private void BoardCreate(BoardPreset boardPreset)
        {
            _cellSize = boardPreset.SizeCell;
            _offsetX = -boardPreset.SizeBoard.x / 2f;
            _offsetY = boardPreset.SizeBoard.y / 2f;
        }

        private void Update()
        {
            if(GameSystem.Data.GamePause) return;

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                float enter;
                if (_plane.Raycast(ray, out enter))
                {
                    Vector3 hitPoint = ray.GetPoint(enter);
                    int x = (int)(hitPoint.x / _cellSize - _offsetX);
                    int y = -(int)(hitPoint.y / _cellSize - _offsetY);
                    
                    Debug.Log("SelectCell " + x + "," + y);
                    BoardSystem.Events.SelectCell?.Invoke(new Vector2Int(x, y));
                }
            }
        }
    }
}

