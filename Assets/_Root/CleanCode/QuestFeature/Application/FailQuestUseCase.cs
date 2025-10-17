using System;
using _Root.CleanCode.QuestFeature.Domain.Ports;

namespace _Root.CleanCode.QuestFeature.Application
{
    public class FailQuestUseCase
    {
        private readonly IQuestRepositoryPort _repo;
        private readonly IQuestEventPort _events;

        public FailQuestUseCase(IQuestRepositoryPort repo, IQuestEventPort eventsPort)
        {
            _repo = repo;
            _events = eventsPort;
        }

        public void Execute(string questId)
        {
            var quest = _repo.GetById(questId);
            quest.Fail();
            _repo.Save(quest);
            _events.OnQuestFailed(quest);
        }
    }
}