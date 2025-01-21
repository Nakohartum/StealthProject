using System;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code
{
    public class Root : MonoBehaviour
    {
        [Inject] private IFactory<PlayerView> _playerFactory;
        private void Start()
        {
            _playerFactory.Create();
        }
    }
}