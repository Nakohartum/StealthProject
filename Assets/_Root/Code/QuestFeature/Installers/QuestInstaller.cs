using _Root.Code.QuestFeature.Controller;
using _Root.Code.QuestFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.QuestFeature.Installers
{
    public class QuestInstaller : MonoInstaller
    {
        [SerializeField] private QuestView _questViewPrefab;
        [SerializeField] private QuestPartView _questPartViewPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<QuestViewFactory>().AsSingle().WithArguments(_questViewPrefab);

            Container.BindFactory<QuestPartView, QuestPartView.QuestPartViewFactory>()
                .FromComponentInNewPrefab(_questPartViewPrefab);
            Container.Bind<QuestManager>().AsSingle().NonLazy();
        }
    }
}