using System;
using UnityEngine;

namespace _Root.Code.Miscellanious
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(this);
        }
    }
}