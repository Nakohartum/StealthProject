using _Root.CleanCode.QuestFeature.Domain;
using _Root.CleanCode.QuestFeature.Domain.Ports;
using _Root.CleanCode.Shared.Ports.Quests;
using Zenject;

namespace _Root.CleanCode.QuestFeature.Infrastructure
{
    public class QuestEventAdapter : IQuestEventPort
    {
        private SignalBus _signalBus;

        public QuestEventAdapter(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void OnQuestStarted(Quest quest)
        {
            _signalBus.TryFire(new QuestStartedSignal(quest.Id, quest.Title));    
        }

        public void OnQuestCompleted(Quest quest)
        {
            _signalBus.TryFire(new QuestCompletedSignal(quest.Id, quest.Title));   
        }

        public void OnQuestFailed(Quest quest)
        {
            _signalBus.TryFire(new QuestFailedSignal(quest.Id, quest.Title));
        }
    }
}