using System;
using UnityEngine;

namespace _Root.Code.SoundManager
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        private static SoundManager _instance;

        public SoundManager Instance
        {
            get
            {
                return _instance;
            }
        }     
        
        private void Start()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlaySound(AudioClip clip)
        {
            _audioSource.Stop();
            _audioSource.clip = clip;
            
            _audioSource.Play();
        }
    }
}