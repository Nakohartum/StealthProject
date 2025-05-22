using UnityEngine;
using Zenject;

namespace _Root.Code.GlobalMusicFeature.GlobalMusicPresenter
{
    public class GlobalMusicInstaller : MonoInstaller
    {
        [SerializeField] private AudioSource _audioSource;

        public override void InstallBindings()
        {
            Container.Bind<GlobalMusicPresenter>().AsSingle().WithArguments(_audioSource);
        }
    }
}