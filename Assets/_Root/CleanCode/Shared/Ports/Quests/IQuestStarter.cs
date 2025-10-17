using System;

namespace _Root.CleanCode.Shared.Ports.Quests
{
    public interface IQuestStarter
    {
        public void StartQuest(string questId);
        event Action<string> OnQuestStarted;
    }
}