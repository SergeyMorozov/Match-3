using System.IO;
using UnityEngine;

namespace  GAME
{
    public class StoreLogic : MonoBehaviour
    {
        private void Awake()
        {
            StoreSystem.Events.Load += Load;
            StoreSystem.Events.Save += Save;
        }

        private string Load(string fileName)
        {
            string pathFull = GetPath(StoreSystem.Settings.SaveDirectory, fileName);
            string json = File.ReadAllText(pathFull);
            return json;
        }

        private void Save(string fileName, string json)
        {
            string pathFull = GetPath(StoreSystem.Settings.SaveDirectory, fileName);
            File.WriteAllText(pathFull, json);
        }

        private string GetPath(string dirName, string fileName)
        {
            string pathDirectory = Application.persistentDataPath + "/" + dirName;
            string pathFile = fileName + "." + StoreSystem.Settings.ExtFile;
            string pathFull = pathDirectory + "/" + pathFile;
            
            if (!Directory.Exists(pathDirectory)) Directory.CreateDirectory(pathDirectory);
            if (!File.Exists(pathFull)) File.Create(pathFull);
            
            return pathFull;
        }
    }
}

