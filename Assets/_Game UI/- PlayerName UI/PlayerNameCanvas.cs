using System;
using UnityEngine;

namespace GAME
{
    public class PlayerNameCanvas : MonoBehaviour
    {
        private static PlayerNameCanvas _instance;

        public static PlayerNameCanvas Instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<PlayerNameCanvas>();
                return _instance;
            }
        }

        // Events
        public Action Show;
        public Action Hide;
        
        // Views
        public PlayerNameView View;
    }
}

