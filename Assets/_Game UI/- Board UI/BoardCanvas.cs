using System;
using UnityEngine;

namespace GAME
{
    public class BoardCanvas : MonoBehaviour
    {
        private static BoardCanvas _instance;

        public static BoardCanvas Instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<BoardCanvas>();
                return _instance;
            }
        }

        // Events
        public Action Show;
        public Action Hide;
        
        // Views
        public BoardView View;
    }
}

