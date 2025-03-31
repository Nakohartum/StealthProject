using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOne.Weapon.WeaponModel
{
    public class MeleeWeaponModel
    {
        public AudioClip[] AttackSounds { get; set; }
        
        public float Damage { get; set; }

        public float DelayBetweenAttacks { get; set; }

        public MeleeWeaponModel(AudioClip[] attackSounds, float damage, float delayBetweenAttacks)
        {
            AttackSounds = attackSounds;
            Damage = damage;
            DelayBetweenAttacks = delayBetweenAttacks;
        }
    }
}