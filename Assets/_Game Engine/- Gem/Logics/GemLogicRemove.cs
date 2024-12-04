using System.Collections.Generic;
using ToolBox.Pools;
using UnityEngine;

namespace  GAME
{
    public class GemLogicRemove : MonoBehaviour
    {
        private List<GemObject> _listRemove;

        private void Awake()
        {
            _listRemove = new List<GemObject>();
            
            BoardSystem.Events.MatchCellsComplete += MatchCellsComplete;
            GemSystem.Events.GemRemove += GemRemove;
        }

        private void GemRemove(GemObject gem)
        {
            if(_listRemove.Contains(gem)) return;
            
            gem.Timer = 1;
            gem.IsReady = false;
            _listRemove.Add(gem);
        }

        private void MatchCellsComplete()
        {
            foreach (GemObject gem in GemSystem.Data.Gems)
            {
                if(!gem.IsMatch) continue;
                GemRemove(gem);
            }
        }

        private void Update()
        {
            for (var i = 0; i < _listRemove.Count; i++)
            {
                var gem = _listRemove[i];
                gem.Timer -= Time.deltaTime / GemSystem.Settings.RemoveDuration;
                gem.Ref.transform.localScale = Vector3.one * gem.Timer;

                if (gem.Timer > 0) continue;

                _listRemove.Remove(gem);
                GemSystem.Data.Gems.Remove(gem);
                gem.gameObject.Release();
                i--;

                if (_listRemove.Count == 0) GemSystem.Events.RemoveComplete?.Invoke();
            }
        }
    }
}

