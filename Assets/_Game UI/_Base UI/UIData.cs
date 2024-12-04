using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class UIData
    {
        public RectTransform MainCanvas;
        public Camera CameraUI;
        public int OpenViewsCounter;
        public List<Action> OpenedViews;
        public bool IsEscDisable;
    }
}
