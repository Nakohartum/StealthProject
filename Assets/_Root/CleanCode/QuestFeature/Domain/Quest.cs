using System.Collections.Generic;
using System.Linq;

namespace _Root.CleanCode.QuestFeature.Domain
{
    public class Quest
    {
        public string Id { get; }
        public string Title { get; }
        public string Description { get; }
        public QuestStatus Status { get; private set; }
        public IReadOnlyList<Objective> Objectives => _objectives;
        private List<Objective> _objectives;

        public Quest(string id, string title, string description, IEnumerable<Objective> objectives)
        {
            _objectives = objectives.ToList();
            Id = id;
            Title = title;
            Description = description;
        }

        public void StartQuest()
        {
            if (Status != QuestStatus.Inactive)
            {
                return;
            }
            Status = QuestStatus.Active;
        }
        
        public void Fail()
        {
            if (Status == QuestStatus.Completed) return;
            Status = QuestStatus.Failed;
        }

        public bool ApplyEvent(ObjectiveEvent ev)
        {
            if (Status != QuestStatus.Active) return false;
            var changed = false;

            foreach (var obj in _objectives)
            {
                changed |= obj.ApplyEvent(ev);
            }

            if (_objectives.Count > 0 && _objectives.TrueForAll(o => o.IsCompleted))
            {
                Status = QuestStatus.Completed;
                changed = true;
            }
            return changed;
        }
    }
}