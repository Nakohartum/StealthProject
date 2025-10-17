using _Root.CleanCode.QuestFeature.Application;
using _Root.CleanCode.QuestFeature.Infrastructure;
using _Root.CleanCode.Shared.Ports.Cutscene;
using _Root.CleanCode.Shared.Ports.Dialog;
using _Root.CleanCode.Shared.Ports.Quests;
using Zenject;

namespace _Root.CleanCode.Events
{
    public class EventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            Container.DeclareSignal<StartQuestUseCase>();
            Container.DeclareSignal<CutsceneFinishedSignal>();
            Container.DeclareSignal<QuestFailedSignal>();
            Container.DeclareSignal<QuestCompletedSignal>();
            Container.DeclareSignal<DialogOptionChosenSignal>();
            
            Container.DeclareSignal<LevelStartedSignal>();
            Container.DeclareSignal<CutscenePlaySignal>();
            Container.DeclareSignal<TriggerReachedSignal>();
            Container.DeclareSignal<GenericLevelEventSignal>();
        }
    }
}