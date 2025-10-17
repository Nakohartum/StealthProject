using System.Collections.Generic;
using System.Linq;
using _Root.CleanCode.QuestFeature.Domain;
using _Root.CleanCode.QuestFeature.Domain.Ports;

namespace _Root.CleanCode.QuestFeature.Infrastructure
{
    public class InMemoryQuestRepository : IQuestRepositoryPort
    {
        private readonly Dictionary<string, Quest> _byId = new Dictionary<string, Quest>(32);

        public InMemoryQuestRepository(IEnumerable<Quest> initial)
        {
            if (initial != null)
            {
                foreach (var q in initial)
                    _byId[q.Id] = q;
            }
        }

        public IReadOnlyList<Quest> GetAll() => _byId.Values.ToList();
        public Quest GetById(string id)
        {
            return _byId.TryGetValue(id, out var q) ? q : null;
        }


        public void Save(Quest quest)
        {
            _byId[quest.Id] = quest;
            // TODO: persist snapshot via Save feature (ISavePort) if needed.
        }

        public IReadOnlyList<Quest> GetActive() => _byId.Values.Where(q => q.Status == QuestStatus.Active).ToList();
    }
}