using UnityEngine;

namespace  GAME
{
    public class KeyboardLogic : MonoBehaviour
    {
        private void Awake()
        {
            
        }

        private void LateUpdate()
        {
            foreach (KeyMapItem keyMapItem in KeyboardSystem.Settings.CurrentKeyMap.Map)
            {
                if (Input.GetKeyDown(keyMapItem.KeyCode))
                {
                    KeyboardSystem.Events.ActionStart?.Invoke(keyMapItem.ActionType);
                }
                
                if (Input.GetKeyUp(keyMapItem.KeyCode))
                {
                    KeyboardSystem.Events.ActionEnd?.Invoke(keyMapItem.ActionType);
                }
            }
        }
    }
}

