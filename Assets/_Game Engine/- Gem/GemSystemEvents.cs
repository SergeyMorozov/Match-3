using System;
using System.Collections.Generic;
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
