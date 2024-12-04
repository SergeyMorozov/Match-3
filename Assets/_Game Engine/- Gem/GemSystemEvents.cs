using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class GemSystemEvents
    {
        public Func<GemPreset, Transform, GemObject> GemCreate;
        public Action<GemObject> GemRemove;
        public Action RemoveComplete;
    }
}
