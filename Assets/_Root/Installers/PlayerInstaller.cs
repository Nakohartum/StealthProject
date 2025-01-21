using _Root.Code.Health;
using GameOne.Player;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerSO _playerSO;
    [SerializeField] private Transform _parent;
    public override void InstallBindings()
    {
        Container.Bind<IFactory<PlayerView>>().To<PlayerFactory>().AsSingle().WithArguments(_playerSO, _parent);
    }
}