using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class SoundLogic : MonoBehaviour
    {
        private void Awake()
        {
            SoundSystem.Events.SoundValue += SoundValue;
            SoundSystem.Events.PlaySound += PlaySound;
            SoundSystem.Events.PlaySoundDelay += PlaySoundDelay;
            SoundSystem.Events.PlaySoundPitch += PlaySoundPitch;
            SoundSystem.Events.StopSound += StopSound;
        }

        private void SoundValue(float value)
        {
            SoundSystem.Data.CurrentSoundVolume = Mathf.Clamp(value, 0, 1);
        }

        private AudioSource GetAudioSource(SoundObject sound)
        {
            AudioSource audioSource = Tools.GetRandomObject(sound.AudioSources);
            float pitch = sound.Preset.Pitch * (1 + Random.Range(-sound.Preset.RandomPitch, sound.Preset.RandomPitch));
            audioSource.pitch = pitch;
            audioSource.volume = sound.Preset.Volume * SoundSystem.Data.CurrentSoundVolume;
            return audioSource;
        }

        private SoundObject PlaySound(SoundPreset preset)
        {
            if (preset == null) return null;

            SoundObject sound = CreateSound(preset);
            AudioSource audioSource = GetAudioSource(sound);
            audioSource.Play();
            return sound;
        }

        private SoundObject PlaySoundDelay(SoundPreset preset, float delay)
        {
            if (preset == null) return null;

            SoundObject sound = CreateSound(preset);
            AudioSource audioSource = GetAudioSource(sound);
            // audioSource.PlayDelayed(delay);
            StartCoroutine(PlayDelay(audioSource, delay));
            return sound;
        }

        private SoundObject PlaySoundPitch(SoundPreset preset, float pitch)
        {
            if (preset == null) return null;

            SoundObject sound = CreateSound(preset);
            AudioSource audioSource = GetAudioSource(sound);
            audioSource.pitch = pitch;
            audioSource.Play();
            return sound;
        }

        private SoundObject CreateSound(SoundPreset preset)
        {
            SoundObject sound = SoundSystem.Data.sounds.Find(s => s.Preset == preset);

            if (sound == null)
            {
                sound = Tools.AddObject<SoundObject>(SoundSystem.Transform);
                sound.name = preset.name;
                sound.Preset = preset;
                sound.AudioSources = new List<AudioSource>();
                foreach (AudioClip clip in preset.Clips)
                {
                    AudioSource audioSource = sound.gameObject.AddComponent<AudioSource>();
                    audioSource.clip = clip;
                    audioSource.loop = preset.Loop;
                    sound.AudioSources.Add(audioSource);
                }
                SoundSystem.Data.sounds.Add(sound);
            }

            return sound;
        }
        
        private void StopSound(SoundObject sound)
        {
            if (sound == null || sound.AudioSources == null || sound.AudioSources.Count == 0)
                return;

            AudioSource audioSource = GetAudioSource(sound);
            audioSource.Stop();
        }

        IEnumerator PlayDelay(AudioSource audioSource, float delay)
        {
            yield return new WaitForSeconds(delay);
            
            audioSource.Play();
        }

    }
}
