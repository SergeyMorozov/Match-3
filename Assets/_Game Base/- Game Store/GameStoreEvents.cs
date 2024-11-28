using System;

namespace GAME
{
    [Serializable]
    public class GameStoreEvents
    {
        public Action<string> Load;
        public Action Save;
        public Action PrepareBlocksForSave;
        public Action<object> AddObjectForSave;
        public Action<object, string, Action> SaveDataByType;

        public Action LoadComplete;
        public Action SaveComplete;

        public Action<string> RequestDataLoad;
        public Action<string, string> RequestDataSave;
        public Action RequestSettings;
        public Action SettingLoaded;
    }
}