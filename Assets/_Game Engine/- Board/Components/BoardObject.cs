using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class BoardObject : MonoBehaviour
    {
        public BoardPreset Preset;
        public BoardRef Ref;
        
        [Header("Data")]
        public GridObject Grid;
    }
}

