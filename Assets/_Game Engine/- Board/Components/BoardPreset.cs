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
        public int StartMoney = 10;
        public int CostTap = 3;
        public int CostMove = 1;
        public int IncomGem = 1;

        [Space]
        public List<GemPreset> Gems;
    }
}

