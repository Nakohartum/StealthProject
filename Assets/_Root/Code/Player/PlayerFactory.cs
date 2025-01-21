using System;
using _Root.Code.Health;
using UnityEngine;
using Zenject;

namespace GameOne.Player
{
    public class PlayerFactory : IFactory<PlayerView>
    {
        private readonly DiContainer _container;
        private readonly PlayerSO _playerSo;
        private Transform _parent;

        public PlayerFactory(DiContainer container, PlayerSO playerSo, Transform parent)
        {
            _container = container;
            _playerSo = playerSo;
            _parent = parent;
        }

        public PlayerView Create()
        {
            var playerGo = _container.InstantiatePrefab(_playerSo.PlayerPrefab, _parent);
            var playerView = playerGo.GetComponent<PlayerView>();
            var health = new Health(100f, 100f);
            var playerModel = new PlayerModel(5f, health);
            return playerView;
        }
    }
}