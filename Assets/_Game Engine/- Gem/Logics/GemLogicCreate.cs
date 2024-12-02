using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class GemLogicCreate : MonoBehaviour
    {
        private void Awake()
        {
            GemSystem.Data.Gems = new List<GemObject>();

            GemSystem.Events.GemCreate += GemCreate;
        }

        private GemObject GemCreate(GemPreset gemPreset, Transform parent)
        {
            GemObject gem = Tools.AddObject<GemObject>(gemPreset.Prefab, parent);
            GemSystem.Data.Gems.Add(gem);
            return gem;
        }
    }
}

