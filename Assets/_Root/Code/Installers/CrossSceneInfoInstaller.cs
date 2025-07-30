using _Root.Code.LevelFeature;
using UnityEngine;
using Zenject;

namespace _Root.Code.Installers
{
    public class CrossSceneInfoInstaller : MonoInstaller
    {
        [SerializeField] private CrossSceneInfo _crossSceneInfo;
        public override void InstallBindings()
        {
            Container.Bind<CrossSceneInfo>().FromInstance(_crossSceneInfo).AsSingle().NonLazy();
        }
    }
}