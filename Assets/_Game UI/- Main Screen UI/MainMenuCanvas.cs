using System;
using UnityEngine;

namespace GAME
{
    public class MainMenuCanvas : MonoBehaviour
    {
        private static MainMenuCanvas _instance;

        public static MainMenuCanvas Instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<MainMenuCanvas>();
                return _instance;
            }
        }

        // Events
        public Action Show;
        public Action Hide;
        
        // Views
        public MainMenuView View;
    }
}

