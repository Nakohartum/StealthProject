using _Root.Code.LevelManager;
using UnityEngine;
using Zenject;

namespace _Root.Code.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private Transform _levelsRoot;
        [SerializeField] private LevelSO[] _levels; 
        public override void InstallBindings()
        {
            Container.Bind<GlobalManagers.LevelManager>().AsSingle().WithArguments(_levelsRoot, _levels).NonLazy();
        }
    }
}