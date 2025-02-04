using _Root.Code.GlobalManagers;
using _Root.Code.LevelManager;
using GameOne.Player;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private LevelSO[] _levels;
    [SerializeField] private Transform _levelContainer;
    
    public override void InstallBindings()
    {
        
        Container.DeclareSignal<PlayerCreatedSignal>();
        Container.Bind<LevelSO[]>().FromInstance(_levels).AsCached();
        Container.Bind<Transform>().FromInstance(_levelContainer).AsCached();
        Container.BindInterfacesAndSelfTo<LevelManager>().AsSingle();
    }
}