using System;

namespace GAME
{
    [Serializable]
    public class SoundEvents
    {
        public Action<float> SoundValue;
        public Func<SoundPreset, SoundObject> PlaySound;
        public Func<SoundPreset, float, SoundObject> PlaySoundDelay;
        public Func<SoundPreset, float, SoundObject> PlaySoundPitch;
        public Action<SoundObject> StopSound;
    }
}