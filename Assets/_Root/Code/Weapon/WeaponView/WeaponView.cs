using System;
using UnityEngine;

namespace GameOne.Weapon.WeaponView
{
    public class WeaponView : MonoBehaviour
    {
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        
        public event Action OnSoundPlay = delegate { };
        
        public void PlaySound()
        {
            OnSoundPlay();
        }
    }
}
