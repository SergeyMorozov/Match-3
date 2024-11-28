using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class GameStoreData
    {
        public DataSave DataSave;
        public string StoreFileName;
        
        public List<T> GetData<T>()
        {
            List<T> list = new List<T>();
            for (var i = 0; i < DataSave.Key.Count; i++)
            {
                if (DataSave.Key[i] != typeof(T).Name) continue;
                list.Add(JsonUtility.FromJson<T>(DataSave.Value[i]));
            }
            return list;
        }
    }

    [Serializable]
    public class DataSave
    {
        public List<string> Key;
        public List<string> Value;
    }

}