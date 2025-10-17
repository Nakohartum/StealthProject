using _Root.CleanCode.Shared.Ports;
using _Root.CleanCode.Shared.Ports.Sounds;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Root.CleanCode.SoundsFeature.Infrastructure
{
    public class SoundsPort : MonoBehaviour, ISoundPortAsync
    {
        [SerializeField] private AudioSource _audioSource;
        private IAddressablesPort _addressablesPort;


        public async UniTask PlayAsync(string sound)
        {
            var clip = await _addressablesPort.LoadAsync<AudioClip>(sound);
            _audioSource.clip = clip;
            _audioSource.Play();
        }

        public async UniTask PlayOneShotAsync(string sound)
        {
            var clip = await _addressablesPort.LoadAsync<AudioClip>(sound);
            _audioSource.PlayOneShot(clip);
        }

        public async UniTask PlayDelayedAsync(string sound, float delay = 0)
        {
            if (delay == 0)
            {
                delay = _audioSource.clip.length;
            }
            var clip = await _addressablesPort.LoadAsync<AudioClip>(sound);
            _audioSource.clip = clip;
            _audioSource.PlayDelayed(delay);
        }

        public void Stop(string sound)
        {
            _audioSource.Stop();
        }
    }
}