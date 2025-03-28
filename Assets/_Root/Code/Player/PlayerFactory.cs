using _Root.Code.Health;
using _Root.Code.Input;
using _Root.Code.MoveFeature;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace GameOne.Player
{
    public class PlayerFactory : IFactory<Transform, PlayerController>
    {
        private PlayerView _playerPrefab;
        private DiContainer _container;
        private readonly InputController _inputController;
        private PlayerSO _playerSo;
        private CinemachineTargetGroup _targetGroup;
        private TickableManager _tickableManager;

        public PlayerFactory(PlayerView playerPrefab, DiContainer container, InputController inputController, PlayerSO playerSo, CinemachineTargetGroup targetGroup, TickableManager tickableManager)
        {
            _playerPrefab = playerPrefab;
            _container = container;
            _inputController = inputController;
            _playerSo = playerSo;
            _targetGroup = targetGroup;
            _tickableManager = tickableManager;
        }
        public PlayerController Create(Transform spawnPoint)
        {
            var health = new Health(_playerSo.HealthSO.MaxHeatlh);
            var model = new PlayerModel(_playerSo.PlayerSpeed, health, _playerSo.StepSounds);
            var playerView =
                _container.InstantiatePrefabForComponent<PlayerView>(_playerPrefab, spawnPoint.position, Quaternion.identity, null);
            var moveController = new PhysicsMovement(playerView.Rigidbody, model.Speed);
            var controller = _container.Instantiate<PlayerController>( new object[]{playerView, _inputController, model, moveController});
            var interactiveObjectChecker =
                new InteractiveObjectsChecker(playerView.Rigidbody, _playerSo.CheckingRadius, _inputController);
            _tickableManager.Add(interactiveObjectChecker);
            _targetGroup.AddMember(playerView.transform, 1f,5f);
            return controller;
        }
    }
}