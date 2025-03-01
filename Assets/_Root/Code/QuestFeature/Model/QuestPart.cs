namespace _Root.Code.QuestFeature.Model
{
    public abstract class QuestPart
    {
        public string Description;
        public bool IsDone;
        public string TargetID;

        protected QuestPart(string description, bool isDone, string targetID)
        {
            Description = description;
            IsDone = isDone;
            TargetID = targetID;
        }
        public abstract void CheckWhetherDone(string targetID);
        
    }
}