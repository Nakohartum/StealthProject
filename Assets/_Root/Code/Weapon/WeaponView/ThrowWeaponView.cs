using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeaponView : MonoBehaviour
{
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    [field: SerializeField] public float NadeLifeTime { get; private set; }
    
}
