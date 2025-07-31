using _Root.Code.Health;
using _Root.Code.Input;
using _Root.Code.LevelFeature;
using _Root.Code.MoveFeature;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace GameOne.Player
{
    public class PlayerFactory : IFactory<Transform, PlayerView>
    {
        private PlayerView _playerPrefab;
        private DiContainer _container;
        private readonly InputController _inputController;
        private PlayerSO _playerSo;
        private CinemachineTargetGroup _targetGroup;
        private TickableManager _tickableManager;
        private readonly LazyInject<PlayerController> _playerController;
        private readonly LazyInject<PlayerModel> _playerModel;
        private CrossSceneInfo _crossSceneInfo;

        public PlayerFactory(PlayerView playerPrefab, DiContainer container,
            InputController inputController, PlayerSO playerSo, 
            CinemachineTargetGroup targetGroup, TickableManager tickableManager, 
        LazyInject<PlayerController> playerController, LazyInject<PlayerModel> playerModel, 
            LevelManager levelManager, CrossSceneInfo crossSceneInfo)
        {
            _playerPrefab = playerPrefab;
            _container = container;
            _inputController = inputController;
            _targetGroup = targetGroup;
            _tickableManager = tickableManager;
            _playerController = playerController;
            _playerSo = playerSo;
            _playerModel = playerModel;
            _crossSceneInfo = crossSceneInfo;
            if (crossSceneInfo.PlayerView != null)
            {
                SetPlayerPrefab(crossSceneInfo.PlayerView);
            }
        }

        private void SetPlayerPrefab(PlayerView playerPrefab)
        {
            _playerPrefab = playerPrefab;
        }


        public PlayerView Create(Transform spawnPoint)
        {
            var playerView =
                _container.InstantiatePrefabForComponent<PlayerView>(_playerPrefab, spawnPoint.position, Quaternion.identity, null);
            var moveController = new PhysicsMovement(playerView.Rigidbody, _playerModel.Value.Speed);
            var interactiveObjectChecker =
                new InteractiveObjectsChecker(playerView.Rigidbody, _playerSo.CheckingRadius, _inputController);
            _tickableManager.Add(interactiveObjectChecker);
            _targetGroup.AddMember(playerView.transform, 1f,5f);
            _playerController.Value.InitializePresenter(playerView, moveController);
            return playerView;
        }
    }
}