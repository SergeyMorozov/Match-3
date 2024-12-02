using UnityEngine;

namespace GAME
{
    public class GemObject : MonoBehaviour
    {
        public GemPreset Preset;
        public GemRef Ref;

        public bool IsReady;
        public bool IsMatch;
        public bool IsSpawn;
        public float Timer;
        public float SpeedMove;
        public Vector3 TargetPoint;
    }
}

