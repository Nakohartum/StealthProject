using System;

namespace _Root.CleanCode.QuestFeature.Domain.QuestTypes
{
    public class CollectObjective : Objective
    {
        public string ItemId;

        public CollectObjective(string itemId, string id, string description, int targetCount = 1) : base(id, QuestType.Collect, description, targetCount)
        {
            ItemId = itemId;
        }

        public override bool ApplyEvent(ObjectiveEvent ev)
        {
            if (IsCompleted)
            {
                return false;
            }

            if (ev.Type != QuestType.Collect)
            {
                return false;
            }

            if (!string.Equals(ev.ItemId, ItemId, StringComparison.Ordinal))
            {
                return false;
            }

            var before = CurrentCount;
            Increment(ev.Amount);
            return CurrentCount != before;
        }
    }
}