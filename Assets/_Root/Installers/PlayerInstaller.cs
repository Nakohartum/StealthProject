using _Root.Code.Health;
using Cinemachine;
using GameOne.Player;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerSO _playerSO;
    [SerializeField] private Transform _parent;
    [SerializeField] private CinemachineTargetGroup _machineTargetGroup;
    public override void InstallBindings()
    {
        Container.Bind<IFactory<PlayerView>>().To<PlayerFactory>().AsSingle().WithArguments(_playerSO, _parent);
        Container.Bind<CinemachineTargetGroup>().FromInstance(_machineTargetGroup).AsSingle();
    }
}