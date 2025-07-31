using _Root.Code.Signals;
using Cinemachine;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code.Installers
{
    public class PlayerSceneContextInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView _playerViewPrefab;
        [SerializeField] private PlayerSO _playerSo;
        [SerializeField] private CinemachineTargetGroup _targetGroup;
        public override void InstallBindings()
        {
            Debug.Log("SceneContext InstallBindings");
            Container.Bind<IFactory<Transform, PlayerView>>().To<PlayerFactory>().AsSingle().WithArguments(_playerViewPrefab, _playerSo, _targetGroup).NonLazy();
        }

        public override void Start()
        {
            var factory = Container.Resolve<IFactory<Transform, PlayerView>>();
            var signalBus = ProjectContext.Instance.Container.Resolve<SignalBus>();
            signalBus.Fire(new PlayerFactoryCreatedSignal { PlayerFactory = factory });
        }
    }
}