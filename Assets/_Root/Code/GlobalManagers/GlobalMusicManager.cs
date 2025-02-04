using System;
using UnityEngine;

namespace _Root.Code.GlobalManagers
{
    public class GlobalMusicManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _musicClips;
        [SerializeField] private AudioSource _audioSource;
        
        public static GlobalMusicManager Instance;
        private static GlobalMusicManager _instance;

        public void SetAmbientAudio(AudioClip clip)
        {
            _audioSource.Stop();
            _audioSource.clip = clip;
            _audioSource.Play();
        }

        public void SetAudioClips(AudioClip[] clips)
        {
            _musicClips = clips;
        }

        public void ChangeMusicRandomly()
        {
            _audioSource.Stop();
            _audioSource.clip = _musicClips[UnityEngine.Random.Range(0, _musicClips.Length)];
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
    }
}