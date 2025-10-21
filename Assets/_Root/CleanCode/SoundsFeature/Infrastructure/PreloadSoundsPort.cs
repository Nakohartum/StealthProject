using System.Collections.Generic;
using _Root.CleanCode.Shared.Ports;
using _Root.CleanCode.Shared.Ports.Sounds;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Root.CleanCode.SoundsFeature.Infrastructure
{
    public class PreloadSoundsPort : MonoBehaviour, ISoundPort
    {
        [SerializeField] private AudioSource _audioSource;
        private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
        private IAddressablesPort _addressablesPort;
        
        public void Play(string sound)
        {
            var clip =  _audioClips[sound];
            _audioSource.clip = clip;
            _audioSource.Play();
        }

        public void PreloadSound(string sound)
        {
            _addressablesPort.LoadAsync<AudioClip>(sound).ContinueWith((clip) => _audioClips.Add(sound, clip));
        }

        public void PlayOneShot(string sound)
        {
            var soundClip = _audioClips[sound];
            _audioSource.PlayOneShot(soundClip);
        }

        public void PlayDelayed(string sound, float delay = 0)
        {
            if (delay == 0)
            {
                delay = _audioSource.clip.length;
            }
            _audioSource.clip = _audioClips[sound];
            _audioSource.PlayDelayed(delay);
        }

        public void Stop(string sound)
        {
            _audioSource.Stop();
        }
    }
}