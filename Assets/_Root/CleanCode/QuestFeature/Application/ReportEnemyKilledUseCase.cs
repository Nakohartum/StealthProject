using _Root.CleanCode.QuestFeature.Domain;
using _Root.CleanCode.QuestFeature.Domain.Ports;

namespace _Root.CleanCode.QuestFeature.Application
{
    public class ReportEnemyKilledUseCase
    {
        private readonly IQuestRepositoryPort _repo;
        private readonly IQuestEventPort _events;

        public ReportEnemyKilledUseCase(IQuestRepositoryPort repo, IQuestEventPort eventsPort)
        {
            _repo = repo;
            _events = eventsPort;
        }

        public void Execute(string enemyId, int amount = 1)
        {
            var evt = new ObjectiveEvent(QuestType.Kill, targetId: enemyId, amount: amount);
            foreach (var q in _repo.GetActive())
            {
                var changed = q.ApplyEvent(evt);
                if (changed)
                {
                    _repo.Save(q);
                    if (q.Status == QuestStatus.Completed) _events.OnQuestCompleted(q);
                }
            }
        }
    }
}