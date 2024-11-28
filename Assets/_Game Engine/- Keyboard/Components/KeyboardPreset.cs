using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class KeyboardPreset : ScriptableObject
    {
        public List<KeyMapItem> Map;
    }

    [Serializable]
    public class KeyMapItem
    {
        public KeyCode KeyCode;
        public ActionType ActionType;
        public string Desc;
    }

    public enum ActionType
    {
        None = 0,
        Esc = 1,
        Back = 2,

        MoveForward = 10,
        MoveBack = 11,
        MoveLeft = 12,
        MoveRight = 13,
        MoveUp = 14,
        MoveDown = 15,
        Jump = 20,
        Crouch = 30,

        PlayerBag = 100,
        
        ActiveBlock = 101,
        UseBlock = 210,
        CloseBlock = 211,

        MultitoolFire = 301,

        MainMenu = 401,
        MainMenuClose = 402,

        BuildMenu = 501,
        
        Slot1 = 601,
        Slot2 = 602,
        Slot3 = 603,
        Slot4 = 604,
        Slot5 = 605,
        Slot6 = 606,
        Slot7 = 607,
        Slot8 = 608,
        Slot9 = 609,

        Tool1 = 611,
        Tool2 = 612,
        Tool3 = 613,
        Tool4 = 614,

        RemoveMode = 701,
        
        Notebook = 801,
        ListQuests = 802,

    }
}

