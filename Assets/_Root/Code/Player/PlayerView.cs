using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOne.Player
{
    public class PlayerView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
    }
}
