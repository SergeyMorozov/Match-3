using System;
using System.Collections;
using System.Collections.Generic;
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
        }

        private void MatchCellsComplete()
        {
            _listRemove.Clear();
            
            foreach (GemObject gem in GemSystem.Data.Gems)
            {
                if(!gem.MatchMarker) continue;
                _listRemove.Add(gem);
            }

            StartCoroutine(RemoveGems());
        }

        IEnumerator RemoveGems()
        {
            float timer = 1;
            while (timer > 0)
            {
                timer -= Time.deltaTime / GemSystem.Settings.RemoveDuration;
                foreach (GemObject gem in _listRemove)
                {
                    gem.Ref.transform.localScale = Vector3.one * timer;
                }

                yield return null;
            }

            foreach (GemObject gem in _listRemove)
            {
                GemSystem.Data.Gems.Remove(gem);
                Destroy(gem.gameObject);
            }
            
            GemSystem.Events.RemoveComplete?.Invoke();
        }
    }
}

