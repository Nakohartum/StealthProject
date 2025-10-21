namespace _Root.CleanCode.QuestFeature.Domain
{
    public readonly struct ObjectiveEvent
    {
        public readonly QuestType Type;
        public readonly string ItemId;
        public readonly string TargetId;
        public readonly int Amount;

        public ObjectiveEvent(QuestType type, string itemId="", string targetId="", int amount=1)
        {
            Type = type;
            ItemId = itemId;
            TargetId = targetId;
            Amount = amount;
        }
    }
}