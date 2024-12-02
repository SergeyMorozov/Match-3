using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class GridSpawnPoint
    {
        public int Index;
        public Vector3 Position;
        public List<GridCell> TargetCells;
    }
}

