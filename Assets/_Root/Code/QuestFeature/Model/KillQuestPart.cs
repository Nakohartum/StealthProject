namespace _Root.Code.QuestFeature.Model
{
    public class KillQuestPart : QuestPart
    {
        public KillQuestPart(string description, bool isDone, string targetID) : base(description, isDone, targetID)
        {
        }

        

        public override void CheckWhetherDone(string targetId)
        {
            if (this.TargetID == targetId)
            {
                IsDone = true;
            }
        }
    }
}