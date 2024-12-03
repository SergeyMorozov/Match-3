using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GAME
{
    public class LeaderboardView : MonoBehaviour
    {
        public int MaxNumberPlayers = 3;
        public Transform Content;
        public LeaderboardInfo Prefab;
        public Button ButtonClose;
    }
}

