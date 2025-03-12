namespace _Root.Code.QuestFeature.Model
{
    public class PickupQuestPart : QuestPart
    {
        public int TargetAmount { get; private set; }
        public int CurrentAmount { get; private set; }
        public PickupQuestPart(string description, bool isDone, string targetID, int targetAmount) : base(description, isDone, targetID)
        {
            TargetAmount = targetAmount;
        }

        public override void CheckWhetherDone(string targetID)
        {
            if (TargetID == targetID)
            {
                CurrentAmount++;
            }

            if (CurrentAmount == TargetAmount)
            {
                IsDone = true;
            }
        }
    }
}