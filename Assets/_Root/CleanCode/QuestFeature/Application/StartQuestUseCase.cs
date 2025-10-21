using System;
using _Root.CleanCode.QuestFeature.Domain.Ports;

namespace _Root.CleanCode.QuestFeature.Application
{
    public class StartQuestUseCase
    {
        private readonly IQuestRepositoryPort _repo;
        private readonly IQuestEventPort _events;

        public StartQuestUseCase(IQuestRepositoryPort repo, IQuestEventPort eventsPort)
        {
            _repo = repo;
            _events = eventsPort;
        }

        public void Execute(string questId)
        {
            var quest = _repo.GetById(questId) ?? throw new ArgumentException($"Quest not found: {questId}");
            quest.StartQuest();
            _repo.Save(quest);
            _events.OnQuestStarted(quest);
        }
    }
}