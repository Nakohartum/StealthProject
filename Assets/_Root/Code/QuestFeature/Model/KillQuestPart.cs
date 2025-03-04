using UnityEngine;

namespace _Root.Code.QuestFeature.Model
{
    public class KillQuestPart : QuestPart
    {
        private int _amount;
        private int _currentAmount = 0;
        public KillQuestPart(string description, bool isDone, string targetID, int amount) : base(description, isDone, targetID)
        {
            _amount = amount;
        }

        

        public override void CheckWhetherDone(string targetId)
        {
            if (this.TargetID == targetId)
            {
                _currentAmount = Mathf.Min(_currentAmount + 1, _amount);
            }

            if (_currentAmount == _amount)
            {
                IsDone = true;
            }
        }
    }
}