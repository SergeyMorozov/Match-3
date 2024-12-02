using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class GridObject : MonoBehaviour
    {
        public GridPreset Preset;
        public GridRef Ref;

        public List<GridCell> ListCells; 
        public Dictionary<Vector2Int, GridCell> Cells;
    }
}

