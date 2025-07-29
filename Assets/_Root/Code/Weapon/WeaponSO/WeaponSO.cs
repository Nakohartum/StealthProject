using System;
using System.Diagnostics;
using _Root.Code.Weapon.WeaponModel;
using GameOne.Weapon.WeaponView;
using UnityEngine;

namespace _Root.Code.Weapon.WeaponSO
{
    [CreateAssetMenu(fileName = nameof(WeaponSO), menuName = "Create/Weapon/" + nameof(WeaponSO), order = 0)]
    public class WeaponSO : ScriptableObject
    {
        [field: SerializeField, Header("General weapon parameters")]
        public WeaponView WeaponPrefab { get; set; }

        [field: SerializeField] public AudioClip[] AttackSounds { get; private set; }
        [field: SerializeField] public WeaponType.WeaponType WeaponType { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }

        [field: SerializeField, Header("Ranged weapon parameters")]
        public float MaxAmmoQuantity { get; private set; }

        [field: SerializeField, Header("Melee weapon parameters")]
        public float DelayBetweenAttacks { get; private set; }

        [field: SerializeField, Header("Throwing weapon parameters")]
        public float FlySpeed { get; private set; }

        [field: SerializeField] public float MaxNadesQuantity { get; private set; }
        [field: SerializeField] public float NadeLifeTime { get; private set; }

        public IAttack CreateWeaponModel()
        {
            switch (WeaponType)
            {
                case Weapon.WeaponType.WeaponType.Melee:
                    return new MeleeWeaponModel(AttackSounds, Damage, DelayBetweenAttacks);
                case Weapon.WeaponType.WeaponType.Ranged:
                    return new RangedWeaponModel(AttackSounds, MaxAmmoQuantity, Damage);
                case Weapon.WeaponType.WeaponType.Throwing:
                    return new ThrowingWeaponModel(AttackSounds, FlySpeed, NadeLifeTime, MaxNadesQuantity);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}