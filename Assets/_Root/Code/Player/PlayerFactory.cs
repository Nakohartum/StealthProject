using System;
using _Root.Code.Health;
using _Root.Code.Input;
using _Root.Code.MoveFeature;
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
            playerGo.transform.SetParent(_parent);
            var playerView = playerGo.GetComponent<PlayerView>();
            var health = new Health(_playerSo.HealthSO.MaxHeatlh);
            var playerModel = new PlayerModel(_playerSo.PlayerSpeed, health);
            var moveController = new PhysicsMovement(playerView.Rigidbody, playerModel.Speed);
            var inputController = _container.Resolve<InputController>();
            var controller = new PlayerController(playerView, inputController, playerModel, moveController);
            _container.BindInstance(controller);
            return playerView;
        }
    }
}