using UnityEngine;

namespace  GAME
{
    public class BoardLogicSpawnGems : MonoBehaviour
    {
        private BoardObject _board;
        private GridObject _grid;
        private int _emptyCells;

        private void Awake()
        {
            GameSystem.Events.GameStart += GameStart;
            BoardSystem.Events.MatchCellsComplete += StartMoveGems;
        }

        private void GameStart()
        {
            _board = BoardSystem.Data.CurrentBoard;
            _grid = _board.Grid;
        }

        private void StartMoveGems()
        {
            for (int x = 0; x < _grid.Size.x; x++)
            {
                int counter = 0;
                for (int y = _grid.Size.y - 1; y >= 0 ; y--)
                {
                    GridCell cell = _grid.Cells[new Vector2Int(x, y)];
                    if(cell.Gem == null) continue;
                    
                    if (cell.Gem.IsMatch)
                    {
                        counter++;
                    }
                    else
                    {
                        if (counter > 0)
                        {
                            GridCell cellTarget = _grid.Cells[new Vector2Int(x, y + counter)];
                            cellTarget.Gem = cell.Gem;
                            cellTarget.Gem.TargetPoint = cellTarget.Position;
                            cell.Gem = null;
                        }
                    }
                }
            }
            
            
            /*foreach (GridCell cell in _grid.ListCells)
            {
                if (cell.Gem == null || !cell.Gem.IsMatch) continue;
            
                _emptyCells = 0;
                SetNewTargetForGems(cell);
                
                GridSpawnPoint spawnPoint = _grid.SpawnPoints.Find(sp => sp.Index == cell.PosInt.x);
                spawnPoint.TargetCells.Add(cell);
            
                GemPreset gemPreset = Tools.GetRandomObject(_board.Preset.Gems);
                GemObject gem = GemSystem.Events.GemCreate?.Invoke(gemPreset, _board.Ref.Gems);
                gem.transform.localPosition = spawnPoint.Position;
                // gem.Ref.SpriteRenderer.transform.localScale = Vector3.zero;
                gem.IsSpawn = true;
            
                cell.Gem = gem;
            }*/
        }

        private void SetNewTargetForGems(GridCell cell)
        {
            if (cell.Gem.IsMatch) _emptyCells++;
            int posY = cell.PosInt.y - 1; 
        }
    }
}

