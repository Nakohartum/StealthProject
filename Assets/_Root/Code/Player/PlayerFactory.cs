using System;
using _Root.Code.Health;
using _Root.Code.Input;
using _Root.Code.MoveFeature;
using _Root.Code.SaveManager;
using Cinemachine;
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
            var targetGroup = _container.Resolve<CinemachineTargetGroup>();
            var playerGo = _container.InstantiatePrefab(_playerSo.PlayerPrefab, _parent);
            playerGo.transform.SetParent(_parent);
            var playerView = playerGo.GetComponent<PlayerView>();
            targetGroup.AddMember(playerGo.transform, 1f, 5f);
            var health = new Health(_playerSo.HealthSO.MaxHeatlh);
            var playerModel = new PlayerModel(_playerSo.PlayerSpeed, health);
            var moveController = new PhysicsMovement(playerView.Rigidbody, playerModel.Speed);
            var inputController = _container.Resolve<InputController>();
            var controller = new PlayerController(playerView, inputController, playerModel, moveController);
            _container.BindInstance(controller);
            var interactiveChecker = new InteractiveObjectsChecker(playerView.Rigidbody, 3f, inputController);
            var tickableManager = _container.Resolve<TickableManager>();
            tickableManager.Add(interactiveChecker);
            return playerView;
        }
    }
}