using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class BoardPreset : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public BoardObject Prefab;

        [Space]
        public GridPreset GridPreset;
        public Vector2Int SizeBoard;
        public float SizeCell;

        [Space]
        public List<GemPreset> Gems;
    }
}

