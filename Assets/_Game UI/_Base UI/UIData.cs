using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
