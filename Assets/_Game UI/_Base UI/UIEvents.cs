using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class UIEvents
    {
        public Action<Action> RegHide;
        public Action<Action> RemoveHide;
        public Action HideAll;

        public Func<Vector3, Vector3> GetScreenFromWorld;
    }
}
