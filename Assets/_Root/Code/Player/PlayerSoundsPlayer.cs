using UnityEngine;

namespace GameOne.Player
{
    public class PlayerSoundsPlayer
    {
        private AudioSource _audioSource;
        private AudioClip[] _stepSounds;

        public PlayerSoundsPlayer(AudioSource audioSource, AudioClip[] stepSounds)
        {
            _audioSource = audioSource;
            _stepSounds = stepSounds;
        }

        public void PlayRandomStepSound()
        {
            var sound = _stepSounds[UnityEngine.Random.Range(0, _stepSounds.Length)];
            _audioSource.PlayOneShot(sound);
        }
    }
}