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
            foreach (GemObject gem in GemSystem.Data.Gems)
            {
                if(gem == null || gem.transform.localPosition == gem.TargetPoint) continue;

                gem.SpeedMove += Time.deltaTime * GemSystem.Settings.SpeedMove;
                float step = Time.deltaTime * gem.SpeedMove;
                if ((gem.TargetPoint - gem.transform.localPosition).magnitude < step)
                {
                    gem.transform.localPosition = gem.TargetPoint;
                    gem.SpeedMove = 0;
                    continue;
                }
                
                gem.transform.localPosition += Vector3.down * step;
            }
            
        }
    }
}

