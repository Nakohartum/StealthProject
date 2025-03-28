using _Root.Code.QuestFeature.Controller;
using _Root.Code.QuestFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.QuestFeature.Installers
{
    public class QuestInstaller : MonoInstaller
    {
        [SerializeField] private Transform _uiRoot;
        [SerializeField] private QuestView _questViewPrefab;
        [SerializeField] private QuestPartView _questPartViewPrefab;

        public override void InstallBindings()
        {
            Container.BindFactory<QuestView, QuestView.QuestViewFactory>().FromComponentInNewPrefab(_questViewPrefab).UnderTransform(_uiRoot);
            Container.BindFactory<QuestPartView, QuestPartView.QuestPartViewFactory>()
                .FromComponentInNewPrefab(_questPartViewPrefab);
            Container.Bind<QuestManager>().AsSingle().NonLazy();
        }
    }
}