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
        private SignalBus _signalBus;

        public PlayerFactory(DiContainer container, PlayerSO playerSo, Transform parent, SignalBus signalBus)
        {
            _container = container;
            _playerSo = playerSo;
            _parent = parent;
            _signalBus = signalBus;
        }

        public PlayerView Create()
        {
            
            var targetGroup = _container.Resolve<CinemachineTargetGroup>();
            var playerGo = _container.InstantiatePrefab(_playerSo.PlayerPrefab, _parent);
            playerGo.transform.SetParent(_parent);
            var playerView = playerGo.GetComponent<PlayerView>();
            _signalBus.Fire(new PlayerCreatedSignal
            {
                PlayerView = playerView,
            });
            _container.BindInstance(playerView);
            targetGroup.AddMember(playerGo.transform, 1f, 5f);
            var health = new Health(_playerSo.HealthSO.MaxHeatlh);
            var playerModel = new PlayerModel(_playerSo.PlayerSpeed, health, _playerSo.StepSounds);
            var moveController = new PhysicsMovement(playerView.Rigidbody, playerModel.Speed);
            var inputController = _container.Resolve<InputController>();
            var controller = new PlayerController(playerView, inputController, playerModel, moveController);
            _container.BindInstance(controller);
            var interactiveChecker = new InteractiveObjectsChecker(playerView.Rigidbody, _playerSo.CheckingRadius, inputController);
            var pickupItemChecker = new PickupItemChecker(playerView.Rigidbody, _playerSo.CheckingRadius, inputController);
            var tickableManager = _container.Resolve<TickableManager>();
            tickableManager.Add(interactiveChecker);
            tickableManager.Add(pickupItemChecker);
            return playerView;
        }
    }
}