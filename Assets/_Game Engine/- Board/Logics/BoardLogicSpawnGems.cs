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
            BoardSystem.Events.MatchCellsComplete += MatchCellsComplete;
        }

        private void GameStart()
        {
            _board = BoardSystem.Data.CurrentBoard;
            _grid = _board.Grid;
        }

        private void MatchCellsComplete()
        {
            PrepareMoveGems();           // Подготовка оставшихся камней к перемещению на место удалённых
            SetTargetForGemsOnSpawn();   // Распределение камней в спавн точках на пустые места
        }
        
        private void PrepareMoveGems()
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
                        // Камень помечен на удаление. Добавляем новый на спавн.
                        counter++;
                        CreateGemOnSpawnPoint(cell);
                        cell.Gem = null;
                    }
                    else
                    {
                        if (counter > 0)
                        {
                            // Назначаем новую точку для перемещения камня
                            GridCell cellTarget = _grid.Cells[new Vector2Int(x, y + counter)];
                            cellTarget.Gem = cell.Gem;
                            cellTarget.Gem.TargetPoint = cellTarget.Position;
                            cellTarget.Gem.SpeedMove = 0;
                            cellTarget.Gem.IsReady = false;
                            cell.Gem = null;
                        }
                    }
                }
            }
        }

        private void CreateGemOnSpawnPoint(GridCell cell)
        {
            GridSpawnPoint spawnPoint = _grid.SpawnPoints.Find(sp => sp.Index == cell.PosInt.x);
            GemPreset gemPreset = Tools.GetRandomObject(_board.Preset.Gems);
            GemObject gem = GemSystem.Events.GemCreate?.Invoke(gemPreset, _board.Ref.Gems);
            gem.transform.localPosition = spawnPoint.Position;
            gem.Ref.Mesh.localScale = Vector3.one * _board.Preset.SizeCell;
            gem.Ref.transform.localScale = Vector3.zero;
            gem.IsSpawn = true;
            gem.Timer = spawnPoint.Gems.Count + 1;
            spawnPoint.Gems.Insert(0, gem);
        }

        private void SetTargetForGemsOnSpawn()
        {
            for (int x = 0; x < _grid.Size.x; x++)
            {
                GridSpawnPoint spawnPoint = _grid.SpawnPoints.Find(sp => sp.Index == x);
                if(spawnPoint.Gems.Count == 0) continue;

                // Заполняем пустые ячейки, до тех пор, пока не встретим ячейку с камнем
                for (int y = 0; y < _grid.Size.y; y++)
                {
                    GridCell cell = _grid.Cells[new Vector2Int(x, y)];
                    if(cell.Gem != null) break;
                    
                    cell.Gem = spawnPoint.Gems[y];
                    cell.Gem.TargetPoint = cell.Position;
                }
                
                spawnPoint.Gems.Clear();
            }
        }
    }
}

