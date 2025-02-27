namespace _Root.Code.QuestFeature.Model
{
    public class LocationQuestPart : QuestPart
    {
        public LocationQuestPart(string description, bool isDone, string targetID) : base(description, isDone, targetID)
        {
        }

        public override void CheckWhetherDone(string targetID)
        {
            if (TargetID == targetID)
            {
                IsDone = true;
            }
        }
    }
}