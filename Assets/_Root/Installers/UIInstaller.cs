using _Root.Code.LevelManager;
using _Root.Code.UI;
using _Root.Code.UI.MainMenu;
using GameOne.Player;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private DialogView _dialogViewPrefab;
    [SerializeField] private MainMenuView _mainMenuViewPrefab;
    [SerializeField] private Transform _root;
    public override void InstallBindings()
    {
        Container.DeclareSignal<DialogCreatedSignal>();
        Container.Bind<UIManager>().AsSingle().WithArguments(_dialogViewPrefab, _mainMenuViewPrefab, _root).NonLazy();
        Container.Bind<DialogController>().AsSingle().NonLazy();
    }
}