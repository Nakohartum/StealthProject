using _Root.Code.Input;
using Cinemachine;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView _playerViewPrefab;
        [SerializeField] private PlayerSO _playerSo;
        [SerializeField] private CinemachineTargetGroup _targetGroup; 
        public override void InstallBindings()
        {
            Container.Bind<IFactory<Transform, PlayerController>>().To<PlayerFactory>().AsSingle().WithArguments(_playerViewPrefab, _playerSo, _targetGroup);
        }
    }
}