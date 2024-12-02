using System;
using UnityEngine;

namespace  GAME
{
    public class BoardLogicMatch : MonoBehaviour
    {
        private BoardObject _board;
        private GridObject _grid;
        
        private void Awake()
        {
            GameSystem.Events.GameStart += GameStart;
            BoardSystem.Events.SelectCell += SelectCell;
        }

        private void GameStart()
        {
            _board = BoardSystem.Data.CurrentBoard;
            _grid = _board.Grid;
        }

        private void SelectCell(Vector2Int v)
        {
            if(!_grid.Cells.ContainsKey(v)) return;

            GemObject gem = _grid.Cells[v].Gem;
            
            Debug.Log("Select Gem " + gem.Preset.Name);
        }

    }
}

