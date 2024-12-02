using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class GemLogicInit : MonoBehaviour
    {
        private void Awake()
        {
            GemSystem.Events.SetGems += SetGems;
        }

        private void SetGems(List<GridCell> listCells, List<GemPreset> listGems, float size, Transform parent)
        {
            GemSystem.Data.Gems = new List<GemObject>();
            
            foreach (GridCell cell in listCells)
            {
                GemPreset gemPreset = Tools.GetRandomObject(listGems);
                GemObject gem = Tools.AddObject<GemObject>(gemPreset.Prefab, parent);
                cell.Gem = gem;
                gem.transform.localPosition = cell.Position;
                gem.Ref.SpriteRenderer.transform.localScale *= size;
                GemSystem.Data.Gems.Add(gem);
            }
        }
    }
}

