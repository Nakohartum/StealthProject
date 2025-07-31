using GameOne.Weapon;
using UnityEngine;

namespace _Root.Code.Weapon.WeaponModel
{
    public class RangedWeaponModel : IAttack
    {
        public AudioClip[] FireSounds { get; set; }

        public float AmmoQuantity { get; set; }

        public float Damage { get; set; }

        public RangedWeaponModel(AudioClip[] fireSounds, float ammoQuantity, float damage)
        {
            FireSounds = fireSounds;
            AmmoQuantity = ammoQuantity;
            Damage = damage;
        }

        public void Attack()
        {
            AmmoQuantity -= 1;
        }
    }
}