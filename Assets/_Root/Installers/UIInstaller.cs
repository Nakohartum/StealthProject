using _Root.Code.CutsceneFeature.Controller;
using _Root.Code.CutsceneFeature.View;
using _Root.Code.LevelManager;
using _Root.Code.QuestFeature.Controller;
using _Root.Code.UI;
using _Root.Code.UI.MainMenu;
using GameOne.Player;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private DialogView _dialogViewPrefab;
    [SerializeField] private MainMenuView _mainMenuViewPrefab;
    [SerializeField] private CutsceneView _cutsceneViewPrefab;
    [SerializeField] private QuestView _questViewPrefab;
    [SerializeField] private QuestPartView _questPartViewPrefab;
    [SerializeField] private Transform _root;
    public override void InstallBindings()
    {
        Container.DeclareSignal<DialogCreatedSignal>();
        Container.DeclareSignal<CutsceneCreatedSignal>();
        Container.Bind<UIManager>().AsSingle().WithArguments(_dialogViewPrefab, _mainMenuViewPrefab, 
            _cutsceneViewPrefab, _questViewPrefab, _root).NonLazy();
        Container.Bind<DialogController>().AsSingle().NonLazy();
        Container.Bind<CutsceneManager>().AsSingle().NonLazy();
        Container.Bind<QuestManager>().AsSingle().WithArguments(_questPartViewPrefab).NonLazy();
    }
}