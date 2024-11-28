using System;
using UnityEngine;

namespace GAME
{
    public class MainScreenCanvas : MonoBehaviour
    {
        private static MainScreenCanvas _instance;

        public static MainScreenCanvas Instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<MainScreenCanvas>();
                return _instance;
            }
        }

        // Events
        public Action Show;
        public Action Hide;
        
        // Views
        public MainScreenView View;
    }
}

