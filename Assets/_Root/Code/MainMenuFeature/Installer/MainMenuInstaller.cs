using _Root.Code.MainMenuFeature.Presenter;
using _Root.Code.MainMenuFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.MainMenuFeature.Installer
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private AudioClip _mainMenuMusic;
        public override void InstallBindings()
        {
            Container.Bind<MainMenuPresenter>().AsSingle().
                WithArguments(new object[]{_mainMenuView, _mainMenuMusic}).NonLazy();
        }
    }
}