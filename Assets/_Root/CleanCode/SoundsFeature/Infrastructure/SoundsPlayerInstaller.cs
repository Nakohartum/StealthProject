using UnityEngine;
using Zenject;

namespace _Root.CleanCode.SoundsFeature.Infrastructure
{
    public class SoundsPlayerInstaller : MonoInstaller
    {
        public bool IsPreloadedPlayer;
        [SerializeField] private SoundsPort _soundsPort;
        [SerializeField] private PreloadSoundsPort _preloadSoundsPort;

        public override void InstallBindings()
        {
            if (IsPreloadedPlayer)
            {
                Container.BindInterfacesAndSelfTo<PreloadSoundsPort>().FromInstance(_preloadSoundsPort).AsSingle().NonLazy();
            }
            else
            {
                Container.BindInterfacesAndSelfTo<SoundsPort>().FromInstance(_soundsPort).AsSingle().NonLazy();
            }
        }
    }
}