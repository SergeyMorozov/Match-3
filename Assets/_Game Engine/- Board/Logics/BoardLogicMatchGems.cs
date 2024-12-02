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
            Debug.Log("Select Gem " + gem.Preset.Name);

            MarkerDestroy(_grid.Cells[v]);
            CheckMatch(_grid.Cells[v], new Vector2Int(1, 0));
            CheckMatch(_grid.Cells[v], new Vector2Int(-1, 0));
            CheckMatch(_grid.Cells[v], new Vector2Int(0, 1));
            CheckMatch(_grid.Cells[v], new Vector2Int(0, -1));
            
            BoardSystem.Events.MatchCellsComplete?.Invoke();
        }

        private void CheckMatch(GridCell cell, Vector2Int offset)
        {
            if(!_grid.Cells.ContainsKey(cell.Index + offset)) return;
            
            GridCell cellMatch = _grid.Cells[cell.Index + offset];
            if(cellMatch.Gem.Preset != cell.Gem.Preset) return;

            MarkerDestroy(cellMatch);
            CheckMatch(cellMatch, offset);
        }

        private void MarkerDestroy(GridCell cell)
        {
            cell.Gem.MatchMarker = true;
            // cell.Gem.Ref.SpriteRenderer.transform.localScale = Vector3.one * 0.1f;
        }

    }
}

