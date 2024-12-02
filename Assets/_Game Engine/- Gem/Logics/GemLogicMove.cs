using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class GemLogicMove : MonoBehaviour
    {
        private void Awake()
        {
            
        }

        private void Update()
        {
            GemSystem.Data.IsBuzyGems = false;
            
            foreach (GemObject gem in GemSystem.Data.Gems)
            {
                if (gem == null || gem.IsReady) continue;

                GemSystem.Data.IsBuzyGems = true;
                
                if (gem.IsSpawn)
                {
                    AnimationSpawn(gem);
                    continue;
                }

                GemMove(gem);
            }
            
        }

        private void AnimationSpawn(GemObject gem)
        {
            gem.Timer -= Time.deltaTime / GemSystem.Settings.SpawnDuration;
            if(gem.Timer > 1) return;

            if (gem.Timer <= 0)
            {
                gem.Timer = 0;
                gem.IsSpawn = false;
            }
            gem.Ref.transform.localScale = Vector3.one * (1 - gem.Timer);
        }

        private void GemMove(GemObject gem)
        {
            gem.SpeedMove += Time.deltaTime * GemSystem.Settings.SpeedMove;
            float step = Time.deltaTime * gem.SpeedMove;
            Vector3 dist = gem.TargetPoint - gem.transform.localPosition;
            if (dist.magnitude <= step)
            {
                gem.transform.localPosition = gem.TargetPoint;
                gem.SpeedMove = 0;
                gem.IsReady = true;
                return;
            }
                
            gem.transform.localPosition += dist.normalized * step;
        }
    }
}

