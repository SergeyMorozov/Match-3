using UnityEngine;

namespace GAME
{
    public class UISystem : MonoBehaviour
    {
        private static UISystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindAnyObjectByType<UISystem>();
        }
        
        public static UISettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new UISettings());
            }
        }
        
        public static UIData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new UIData());
            }
        }

        public static UIEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new UIEvents());
            }
        }
        
        [SerializeField] private UISettings settings;
        [SerializeField] private UIData data;
        private UIEvents events;
    }

}

