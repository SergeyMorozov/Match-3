using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class GridLogicCreate : MonoBehaviour
    {
        private float _offsetX;
        private float _offsetY;
        
        private void Awake()
        {
            GridSystem.Events.GridCreate += GridCreate;
        }

        private GridObject GridCreate(GridPreset gridPreset, Transform parent, Vector2Int sizeGrid, float sizeCell)
        {
            GridObject grid = Tools.AddObject<GridObject>(gridPreset.Prefab, parent);
            GridSystem.Data.CurrentGrid = grid;

            grid.Size = sizeGrid;
            float w = sizeGrid.x * sizeCell + grid.Preset.BorderWidth;
            float h = sizeGrid.y * sizeCell + grid.Preset.BorderWidth;
            grid.Ref.Border.size = new Vector2(w, h);

            _offsetX = (-sizeGrid.x / 2f + 0.5f) * sizeCell;
            _offsetY = (sizeGrid.y / 2f - 0.5f) * sizeCell;
            
            CreateCells(grid, sizeGrid, sizeCell);
            CreateSpawnPoints(grid, sizeGrid, sizeCell);
            
            return grid;
        }

        private void CreateCells(GridObject grid, Vector2Int sizeGrid, float sizeCell)
        {
            grid.ListCells = new List<GridCell>();
            grid.Cells = new Dictionary<Vector2Int, GridCell>();
            
            for (int y = 0; y < sizeGrid.y; y++)
            {
                for (int x = 0; x < sizeGrid.x; x++)
                {
                    int index = (y % 2 + x % 2) % 2;
                    SpriteRenderer cellPrefab = index == 0 ? grid.Ref.Cell1 : grid.Ref.Cell2;
                    SpriteRenderer cell = Tools.AddObject<SpriteRenderer>(cellPrefab, grid.transform);
                    cell.size = new Vector2(sizeCell, sizeCell);
                    Vector3 position = new Vector3(_offsetX + x * sizeCell, _offsetY - y * sizeCell, 0);
                    cell.transform.localPosition = position;

                    GridCell gridCell = new GridCell();
                    gridCell.PosInt = new Vector2Int(x, y);
                    gridCell.Position = position;
                    grid.ListCells.Add(gridCell);
                    grid.Cells.Add(gridCell.PosInt, gridCell);
                }
            }
            
            grid.Ref.Cell1.gameObject.SetActive(false);
            grid.Ref.Cell2.gameObject.SetActive(false);
        }

        private void CreateSpawnPoints(GridObject grid, Vector2Int sizeGrid, float sizeCell)
        {
            grid.SpawnPoints = new List<GridSpawnPoint>();

            for (int x = 0; x < sizeGrid.x; x++)
            {
                GridSpawnPoint spawnPoint = new GridSpawnPoint();
                spawnPoint.Gems = new List<GemObject>();
                spawnPoint.Index = x;
                spawnPoint.Position = new Vector3(_offsetX + x * sizeCell, _offsetY + sizeCell, 0);
                grid.SpawnPoints.Add(spawnPoint);
            }
        }
    }
}

