using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOne.Weapon.WeaponModel
{
    public class ThowWeaponModel
    {
        public AudioClip[] ExplodeSounds { get; set; }
        
        public float FlySpeed {get; set;}
        
        public float NadeLifeTime {get; set;}

        public ThowWeaponModel(AudioClip[] explodeSounds,float flySpeed, float nadeLifeTime)
        {
            ExplodeSounds = explodeSounds;
            FlySpeed = flySpeed;
            NadeLifeTime = nadeLifeTime;
        }
    }
}