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
            string pathFull = GetPath(fileName);
            string json = File.ReadAllText(pathFull);
            return json;
        }

        private void Save(string fileName, string json)
        {
            string pathFull = GetPath(fileName);
            File.WriteAllText(pathFull, json);
        }

        private string GetPath(string fileName)
        {
            string pathDirectory = Path.Combine(Application.streamingAssetsPath, StoreSystem.Settings.SaveDirectory);
            string pathFull = Path.Combine(pathDirectory, fileName + StoreSystem.Settings.ExtFile);
            
            if (!Directory.Exists(pathDirectory)) Directory.CreateDirectory(pathDirectory);
            if (!File.Exists(pathFull))
            {
                var stream = File.Create(pathFull);
                stream.Dispose();
                stream.Close();
            }
            
            return pathFull;
        }
    }
}

