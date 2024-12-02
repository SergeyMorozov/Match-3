using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class GridSystemEvents
    {
        public Func<GridPreset, Transform, Vector2Int, float, GridObject> GridCreate;
    }
}
