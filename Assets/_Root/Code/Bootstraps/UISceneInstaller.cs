using _Root.Code.DialogFeature.Factory;
using _Root.Code.DialogFeature.Presenter;
using _Root.Code.DialogFeature.SO;
using _Root.Code.QuestFeature;
using _Root.Code.QuestFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.Bootstraps
{
    public class UISceneInstaller : MonoInstaller
    {
        [SerializeField] private Transform _root;
        public override void InstallBindings()
        {
             
        }

        public override void Start()
        {
            var dialogFactory = Container.Resolve<IFactory<Dialog, DialogPresenter>>() as DialogFactory;
            var questViewfactory = Container.Resolve<IFactory<QuestView>>() as QuestViewFactory;
            dialogFactory.SetRoot(_root);
            questViewfactory.SetRoot(_root);
        }
    }
}