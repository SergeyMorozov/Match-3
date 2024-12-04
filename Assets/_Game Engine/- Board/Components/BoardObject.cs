using UnityEngine;

namespace GAME
{
    public class BoardObject : MonoBehaviour
    {
        public BoardPreset Preset;
        public BoardRef Ref;
        
        [Header("Data")]
        public GridObject Grid;
        public int Move;
        public int Money;
        public int MoneyChange;
        public int Cost;
        public int Score;
        public int ScoreChange;
    }
}

