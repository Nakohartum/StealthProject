using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeWeaponView : MonoBehaviour
{
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    [field: SerializeField] public float AmmoQuantity { get; private set; }
}
