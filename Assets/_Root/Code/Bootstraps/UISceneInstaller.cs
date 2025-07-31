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
             Container.BindInterfacesAndSelfTo<DialogFactoryInitializer>().AsSingle().WithArguments(_root).NonLazy();
             Container.BindInterfacesAndSelfTo<QuestFactoryInitializer>().AsSingle().WithArguments(_root).NonLazy();
        }

        
    }
}