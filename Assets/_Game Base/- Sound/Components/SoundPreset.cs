using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GAME
{
    public class SoundPreset : ScriptableObject
    {
        public string Name;
        public string Desc;
        
        public List<AudioClip> Clips;
        
        [Range(0f, 1f)] public float Volume = 1;
        [Range(-2f, 2f)] public float Pitch = 1;
        [Range(0f, 1f)] public float RandomPitch;

        public bool Loop;
        
    }
}
