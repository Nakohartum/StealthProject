namespace _Root.CleanCode.QuestFeature.Domain.Ports
{
    public interface IQuestEventPort
    {
        void OnQuestStarted(Quest quest);

        void OnQuestCompleted(Quest quest);

        void OnQuestFailed(Quest quest);
    }
}