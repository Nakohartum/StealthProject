using System;

namespace _Root.CleanCode.QuestFeature.Domain.QuestTypes
{
    public class KillObjective : Objective
    {
        public string TargetEnemyId;

        public KillObjective(string targetEnemyId, string id, string description, int targetCount = 1) : base(id, QuestType.Kill, description, targetCount)
        {
            TargetEnemyId = targetEnemyId;
        }

        public override bool ApplyEvent(ObjectiveEvent ev)
        {
            if (IsCompleted) return false;
            if (ev.Type != QuestType.Kill) return false;
            if (!string.Equals(ev.TargetId, TargetEnemyId, StringComparison.Ordinal)) return false;

            var before = CurrentCount;
            Increment(ev.Amount);
            return CurrentCount != before;
        }
    }
}