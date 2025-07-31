using GameOne.Weapon;
using UnityEngine;

namespace _Root.Code.Weapon.WeaponModel
{
    public class ThrowingWeaponModel : IAttack
    {
        private readonly float _nadesQuantity;
        public AudioClip[] ExplodeSounds { get; set; }
        
        public float FlySpeed {get; set;}
        
        public float NadeLifeTime {get; set;}
        
        public float NadesQuantity {get; set;}
        

        public ThrowingWeaponModel(AudioClip[] explodeSounds,float flySpeed, float nadeLifeTime, float nadesQuantity)
        {
            _nadesQuantity = nadesQuantity;
            ExplodeSounds = explodeSounds;
            FlySpeed = flySpeed;
            NadeLifeTime = nadeLifeTime;
        }

        public void Attack()
        {
            NadesQuantity -= 1;
        }
    }
}