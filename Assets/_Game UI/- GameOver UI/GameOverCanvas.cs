using System;
using UnityEngine;

namespace GAME
{
    public class GameOverCanvas : MonoBehaviour
    {
        private static GameOverCanvas _instance;

        public static GameOverCanvas Instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<GameOverCanvas>();
                return _instance;
            }
        }

        // Events
        public Action Show;
        public Action Hide;
        
        // Views
        public GameOverView View;
    }
}

