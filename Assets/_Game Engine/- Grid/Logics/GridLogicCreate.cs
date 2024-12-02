using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class GridLogicCreate : MonoBehaviour
    {
        private void Awake()
        {
            GridSystem.Events.GridCreate += GridCreate;
        }

        private GridObject GridCreate(GridPreset gridPreset, Transform parent, Vector2Int sizeGrid, float sizeCell)
        {
            GridObject grid = Tools.AddObject<GridObject>(gridPreset.Prefab, parent);
            grid.ListCells = new List<GridCell>();
            grid.Cells = new Dictionary<Vector2Int, GridCell>();
            float w = sizeGrid.x * sizeCell + gridPreset.BorderWidth;
            float h = sizeGrid.y * sizeCell + gridPreset.BorderWidth;
            grid.Ref.Border.size = new Vector2(w, h);

            float offsetX = (-sizeGrid.x / 2f + 0.5f) * sizeCell;
            float offsetY = (sizeGrid.y / 2f - 0.5f) * sizeCell;
            
            for (int y = 0; y < sizeGrid.y; y++)
            {
                for (int x = 0; x < sizeGrid.x; x++)
                {
                    int index = (y % 2 + x % 2) % 2;
                    SpriteRenderer cellPrefab = index == 0 ? grid.Ref.Cell1 : grid.Ref.Cell2;
                    SpriteRenderer cell = Tools.AddObject<SpriteRenderer>(cellPrefab, grid.transform);
                    cell.size = new Vector2(sizeCell, sizeCell);
                    Vector3 position = new Vector3(offsetX + x * sizeCell, offsetY - y * sizeCell, 0);
                    cell.transform.localPosition = position;

                    GridCell gridCell = new GridCell();
                    gridCell.Index = new Vector2Int(x, y);
                    gridCell.Position = position;
                    grid.ListCells.Add(gridCell);
                    grid.Cells.Add(gridCell.Index, gridCell);
                }
            }
            
            grid.Ref.Cell1.gameObject.SetActive(false);
            grid.Ref.Cell2.gameObject.SetActive(false);

            GridSystem.Data.CurrentGrid = grid;
            
            return grid;
        }
    }
}

