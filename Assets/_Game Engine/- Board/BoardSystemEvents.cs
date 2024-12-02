using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class BoardSystemEvents
    {
        public Action<BoardPreset> BoardCreate;
        public Action<Vector2Int> SelectCell;
        public Action MatchCellsComplete;
    }
}
