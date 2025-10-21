using System;

namespace _Root.CleanCode.QuestFeature.Domain.QuestTypes
{
    public class ReachObjective : Objective
    {
        public string LocationId { get; }
        public ReachObjective(string locationId, string id, string description, int targetCount = 1) : base(id, QuestType.Reach, description, targetCount)
        {
            LocationId = locationId;
        }

        
        public override bool ApplyEvent(ObjectiveEvent ev)
        {
            if (IsCompleted) return false;
            if (ev.Type != QuestType.Reach) return false;
            if (!string.Equals(ev.TargetId, LocationId, StringComparison.Ordinal)) return false;

            var before = CurrentCount;
            Increment(ev.Amount);
            return CurrentCount != before;
        }
    }
}