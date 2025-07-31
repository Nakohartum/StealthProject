using UnityEngine;

namespace _Root.Code.Weapon.WeaponSoundsPlayer
{
    public class WeaponsSoundsPlayer
    {
        private AudioSource _audioSource;
        private AudioClip[] _weaponSounds;

        public WeaponsSoundsPlayer(AudioSource audioSource, AudioClip[] weaponSounds)
        {
            _audioSource = audioSource;
            _weaponSounds = weaponSounds;
        }

        public void PlayRandomWeaponSounds()
        {
            var weaponSound = _weaponSounds[UnityEngine.Random.Range(0, _weaponSounds.Length)];
            _audioSource.PlayOneShot(weaponSound);
        }
    }
}