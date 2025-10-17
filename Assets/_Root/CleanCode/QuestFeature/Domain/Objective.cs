using System;

namespace _Root.CleanCode.QuestFeature.Domain
{
    [Serializable]
    public abstract class Objective
    {
        public string Id;
        public QuestType Type;
        public string Description;
        public bool IsCompleted;
        public int CurrentCount { get; protected set; }
        public int TargetCount { get; }

        public Objective(string id, QuestType type, string description, int targetCount = 1)
        {
            Id = id;
            Type = type;
            Description = description;
            TargetCount = targetCount;
            CurrentCount = 0;
            IsCompleted = false;
        }

        public abstract bool ApplyEvent(ObjectiveEvent ev);

        protected void Increment(int amount = 1)
        {
            if (IsCompleted)
            {
                return;
            }
            CurrentCount = Math.Min(TargetCount, CurrentCount + amount);
            if (CurrentCount >= TargetCount)
                IsCompleted = true;
        }
    }
}