using System.Collections.Generic;
using ToolBox.Pools;
using UnityEngine;

namespace  GAME
{
    public class GemLogicCreate : MonoBehaviour
    {
        private void Awake()
        {
            GemSystem.Data.Gems = new List<GemObject>();

            GameSystem.Events.GameInit += GameInit;
            GemSystem.Events.GemCreate += GemCreate;
        }

        private void GameInit()
        {
            foreach (GemPreset gemPreset in GemSystem.Settings.Gems)
            {
                gemPreset.Prefab.gameObject.Populate(GemSystem.Settings.PopulateGems);
            }
        }

        private GemObject GemCreate(GemPreset gemPreset, Transform parent)
        {
            GemObject gem = gemPreset.Prefab.gameObject.Reuse<GemObject>();
            gem.transform.SetParent(parent);
            gem.transform.localPosition = Vector3.zero;
            gem.IsMatch = false;
            gem.IsReady = false;
            gem.IsSpawn = false;
            GemSystem.Data.Gems.Add(gem);
            return gem;
        }
    }
}

