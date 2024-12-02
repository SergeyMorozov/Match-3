using System;
using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class BoardLogicMatchGems : MonoBehaviour
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
            if(gem == null || !gem.IsReady) return;
            
            // Debug.Log("Select Gem " + gem.Preset.Name);

            MarkerMatch(_grid.Cells[v]);
            CheckMatch(_grid.Cells[v], new Vector2Int(1, 0));
            CheckMatch(_grid.Cells[v], new Vector2Int(-1, 0));
            CheckMatch(_grid.Cells[v], new Vector2Int(0, 1));
            CheckMatch(_grid.Cells[v], new Vector2Int(0, -1));
            
            BoardSystem.Events.MatchCellsComplete?.Invoke();
        }

        private void CheckMatch(GridCell cell, Vector2Int offset)
        {
            if(!_grid.Cells.ContainsKey(cell.PosInt + offset)) return;
            
            GridCell cellMatch = _grid.Cells[cell.PosInt + offset];
            if(cellMatch.Gem == null || cellMatch.Gem.Preset != cell.Gem.Preset) return;

            MarkerMatch(cellMatch);
            CheckMatch(cellMatch, offset);
        }

        private void MarkerMatch(GridCell cell)
        {
            cell.Gem.IsReady = false;
            cell.Gem.IsMatch = true;
        }

    }
}

