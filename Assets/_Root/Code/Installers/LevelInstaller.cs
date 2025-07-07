using _Root.Code.AStar.Debugger;
using _Root.Code.LevelManager;
using UnityEngine;
using Zenject;

namespace _Root.Code.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private Transform _levelsRoot;
        [SerializeField] private LevelSO[] _levels; 
        [SerializeField] private GridDebugger _gridDebugger;
        public override void InstallBindings()
        {
            Container.Bind<GlobalManagers.LevelManager>().AsSingle().WithArguments(_levelsRoot, _levels).NonLazy();
            Container.Bind<GridDebugger>().FromInstance(_gridDebugger).AsSingle();
        }
    }
}