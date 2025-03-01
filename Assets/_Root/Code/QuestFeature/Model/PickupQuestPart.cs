namespace _Root.Code.QuestFeature.Model
{
    public class PickupQuestPart : QuestPart
    {
        private int _targetAmount;
        private int _currentAmount;
        public PickupQuestPart(string description, bool isDone, string targetID, int targetAmount) : base(description, isDone, targetID)
        {
            _targetAmount = targetAmount;
        }

        public override void CheckWhetherDone(string targetID)
        {
            if (TargetID == targetID)
            {
                _currentAmount++;
            }

            if (_currentAmount == _targetAmount)
            {
                IsDone = true;
            }
        }
    }
}