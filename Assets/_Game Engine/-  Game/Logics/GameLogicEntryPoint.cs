using UnityEngine;
using Random = UnityEngine.Random;

namespace  GAME
{
    public class GameLogicEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            Random.InitState(0);
            Application.targetFrameRate = 1000;
            
            GameSystem.Data.GamePause = true;
            GameSystem.Data.GamePlaying = false;
        }

        private void Start()
        {
            GameSystem.Events.GameInit?.Invoke();
            GameSystem.Events.GameMainMenuShow?.Invoke();
        }

        private void Update()
        {
            if(GameSystem.Data.GamePause || !GameSystem.Data.GamePlaying) return;
            GameSystem.Data.TimeGamePlay += Time.deltaTime;
        }

        /*
       private void OnApplicationPause(bool pauseStatus)
        {
            if (GameSystem.Data.GamePause != pauseStatus)
            {
                GameSystem.Data.GamePause = pauseStatus;
            }
        }
        */

    }
}

