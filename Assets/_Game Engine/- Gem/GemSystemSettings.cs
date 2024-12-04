using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class GemSystemSettings : ScriptableObject
    {
        public float RemoveDuration = 0.5f;
        public float SpawnDuration = 0.2f;
        public float SpeedMove = 2f;

        [Header("Pool")]
        public int PopulateGems = 20;
        public List<GemPreset> Gems;
    }
}
