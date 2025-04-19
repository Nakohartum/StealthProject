using _Root.Code.MainMenuFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.MainMenuFeature.Installer
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private Transform _root;
        [SerializeField] private MainMenuView _mainMenuViewPrefab;
        [SerializeField] private AudioClip _mainMenuMusic;
        public override void InstallBindings()
        {
            Container.BindFactory<MainMenuView, MainMenuView.Factory>().FromComponentInNewPrefab(_mainMenuViewPrefab)
                .UnderTransform(_root);
            Container.Bind<MainMenuManager.MainMenuManager>().AsSingle().WithArguments(_mainMenuMusic).NonLazy();
        }
    }
}