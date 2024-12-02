using UnityEngine;

namespace GAME
{
    public class GemObject : MonoBehaviour
    {
        public GemPreset Preset;
        public GemRef Ref;

        public Vector3 TargetPoint;
        public bool IsMatch;
        public bool IsSpawn;
        public float Timer;
        public float SpeedMove;
    }
}

