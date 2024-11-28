using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GAME
{
    public class SoundObject : MonoBehaviour
    {
        public SoundPreset Preset;
        public List<AudioSource> AudioSources;
    }
}
