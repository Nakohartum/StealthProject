using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOne.Weapon.WeaponModel
{
    public class StrikeWeaponModel : MonoBehaviour
    {
        public AudioClip[] FireSounds { get; set; }

        public float AmmoQuantity { get; set; }

        public float Damage { get; set; }

        public StrikeWeaponModel(AudioClip[] fireSounds, float ammoQuantity, float damage)
        {
            FireSounds = fireSounds;
            AmmoQuantity = ammoQuantity;
            Damage = damage;
        }
    }
}