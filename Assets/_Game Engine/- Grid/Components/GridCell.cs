using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class GridCell
    {
        public Vector2Int PosInt;
        public Vector3 Position;
        public GemObject Gem;
    }
}

