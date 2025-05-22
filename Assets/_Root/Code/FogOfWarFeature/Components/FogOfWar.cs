using System;
using UnityEngine;

namespace _Root.Code.FogOfWarFeature.Components
{
    public class FogOfWar : MonoBehaviour
    {
        
        public void FogOfWarStart() => gameObject.SetActive(true);
        public void FogOfWarStop() => gameObject.SetActive(false);
        
    }
}