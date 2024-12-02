using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class GemSystemEvents
    {
        public Action<List<GridCell>, List<GemPreset>, float, Transform> SetGems;
    }
}
