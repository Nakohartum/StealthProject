using System;

namespace _Root.CleanCode.QuestFeature.Domain.QuestTypes
{
    public class DeliverObjective :  Objective
    {
        public string ItemId;
        public string ReceiverId;

        public DeliverObjective(string itemId, string receiverId, string id, string description, int targetCount = 1) : base(id, QuestType.Deliver, description, targetCount)
        {
            ItemId = itemId;
            ReceiverId = receiverId;
        }

        public override bool ApplyEvent(ObjectiveEvent ev)
        {
            if (IsCompleted) return false;
            if (ev.Type != QuestType.Deliver) return false;
            if (!string.Equals(ev.ItemId, ItemId, StringComparison.Ordinal)) return false;
            if (!string.Equals(ev.TargetId, ReceiverId, StringComparison.Ordinal)) return false;

            var before = CurrentCount;
            Increment(ev.Amount);
            return CurrentCount != before;
        }
    }
}