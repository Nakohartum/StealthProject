using System.Collections.Generic;

namespace _Root.CleanCode.QuestFeature.Domain.Ports
{
    public interface IQuestRepositoryPort
    {
        IReadOnlyList<Quest> GetAll();
        Quest GetById(string id);
        
        void Save(Quest quest);
        
        IReadOnlyList<Quest> GetActive();
    }
}