using UnityEngine;

namespace _Root.Code.InteractiveObjects.InteractionStrategy
{
    public class PlaySoundsStrategy : IInteractionStrategy
    {
        private AudioSource _audioSource;
        private AudioClip _onClip;
        private AudioClip _offClip;
        private AudioClip _loopClip;
        private bool _isToggled;

        public PlaySoundsStrategy(AudioSource audioSource, AudioClip onClip, AudioClip offClip, AudioClip loopClip)
        {
            _audioSource = audioSource;
            _onClip = onClip;
            _offClip = offClip;
            _loopClip = loopClip;
        }
        
        public void Interact()
        {
            
            _audioSource.Stop();
            if (!_isToggled)
            {
                if (_onClip != null)
                {
                    SetupAudioSource(_onClip);
                    _audioSource.Play();
                }
                if (_loopClip != null)
                {
                    SetupAudioSource(_loopClip, true);
                    _audioSource.PlayDelayed(_onClip != null ? _onClip.length : 0);
                }
                _isToggled = true;
            }
            else
            {
                if (_offClip != null)
                {
                    SetupAudioSource(_offClip);
                    _audioSource.Play();
                }
                _isToggled = false;
            }
        }

        private void SetupAudioSource(AudioClip clip, bool isLoop = false)
        {
            _audioSource.clip = clip;
            _audioSource.loop = isLoop;
        }
    }
}