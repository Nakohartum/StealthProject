using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Root.Code.GlobalManagers
{
    public class GlobalMusicManager : MonoBehaviour
    {
        [SerializeField] private List<EditorHelpers.KeyValuePair<string, AudioClip>> _musicClips;
        [SerializeField] private AudioSource _audioSource;
        
        public static GlobalMusicManager Instance => _instance;
        private static GlobalMusicManager _instance;
        
        public void SetAmbientAudio(AudioClip clip)
        {
            _audioSource.Stop();
            _audioSource.clip = clip;
            _audioSource.Play();
        }

        public void StartAudioByName(string name, bool isLooping = false)
        {
            _audioSource.Stop();
            _audioSource.loop = isLooping;
            _audioSource.clip = _musicClips.Find(x => x.Key == name).Value;
            _audioSource.Play();
        }

        public void SetAudioClips(List<EditorHelpers.KeyValuePair<string, AudioClip>> clips)
        {
            _musicClips = clips;
        }

        public void ChangeMusicRandomly()
        {
            _audioSource.Stop();
            _audioSource.clip = _musicClips[UnityEngine.Random.Range(0, _musicClips.Count)].Value;
            _audioSource.Play();
        }
        
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        public void StopMusic()
        {
            _audioSource.Stop();
        }
    }
}