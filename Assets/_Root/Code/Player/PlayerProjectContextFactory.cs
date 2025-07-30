using _Root.Code.Health;
using _Root.Code.Input;
using _Root.Code.MoveFeature;
using UnityEngine;
using Zenject;

namespace GameOne.Player
{
    public class PlayerProjectContextFactory
    {
        private PlayerSO _playerSo;
        private DiContainer _container;
        private readonly InputController _inputController;

        public PlayerProjectContextFactory(PlayerSO playerSo, InputController inputController, DiContainer container)
        {
            _playerSo = playerSo;
            _inputController = inputController;
            _container = container;
        }

        public void Create()
        {
            var health = new Health(_playerSo.HealthSO.MaxHeatlh);
            var playerModel = new PlayerModel(_playerSo.PlayerSpeed, health, _playerSo.StepSounds);
            _container.Bind<PlayerModel>().FromInstance(playerModel).AsSingle();
            var playerController =
                _container.Instantiate<PlayerController>(new object[] { _inputController, playerModel });
            _container.Bind<PlayerController>().FromInstance(playerController).AsSingle();
        }
    }
}