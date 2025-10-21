namespace _Root.CleanCode.Shared.Ports.Quests
{
    public readonly struct QuestStartedSignal
    {
        public readonly string Id;
        public readonly string Title;
        public QuestStartedSignal(string id, string title)
        {
            Id = id; Title = title;
        }
    }

    public readonly struct QuestCompletedSignal
    {
        public readonly string Id;
        public readonly string Title;
        public QuestCompletedSignal(string id, string title)
        {
            Id = id; Title = title;
        }
    }

    public readonly struct QuestFailedSignal
    {
        public readonly string Id;
        public readonly string Title;
        public QuestFailedSignal(string id, string title)
        {
            Id = id; Title = title;
        }
    }
}