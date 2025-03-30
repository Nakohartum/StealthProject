using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponView : MonoBehaviour
{
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    [field: SerializeField] public float StaminaCost { get; private set; }
}
