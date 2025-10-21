using System.Collections.Generic;
using System.Linq;
using _Root.CleanCode.QuestFeature.Application;
using _Root.CleanCode.QuestFeature.Domain.Ports;
using _Root.CleanCode.Shared.Ports.Quests;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.QuestFeature.Infrastructure
{
    public class GlobalQuestsInstaller : MonoInstaller
    {
        [Header("Definitions")]        
        [SerializeField] private List<ScriptableQuestConfig> _questConfigs  = new List<ScriptableQuestConfig>();

        public override void InstallBindings()
        {
            var quests = _questConfigs.Select(c => c.ToDomain()).Where(q => q != null).ToList();
            Container.Bind<IQuestRepositoryPort>().To<InMemoryQuestRepository>().AsSingle().WithArguments(quests);
            Container.Bind<IQuestEventPort>().To<QuestEventAdapter>().AsSingle();
            Container.Bind<StartQuestUseCase>().AsTransient();
            Container.Bind<ReportItemCollectedUseCase>().AsTransient();
            Container.Bind<ReportItemDeliveredUseCase>().AsTransient();
            Container.Bind<ReportEnemyKilledUseCase>().AsTransient();
            Container.Bind<ReportLocationReachedUseCase>().AsTransient();
            Container.Bind<FailQuestUseCase>().AsTransient();
            
        }
    }
}