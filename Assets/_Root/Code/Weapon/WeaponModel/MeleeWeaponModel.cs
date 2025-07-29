using GameOne.Weapon;
using UnityEngine;

namespace _Root.Code.Weapon.WeaponModel
{
    public class MeleeWeaponModel : IAttack
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

        public void Attack()
        {
            //TODO Придумать, что сюда засунуть 
        }
    }
}