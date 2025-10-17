using _Root.CleanCode.LevelFeature.Domain;

namespace _Root.CleanCode.QuestFeature.Infrastructure
{ 
    public interface ILevelControl
    {
        void StartLevel(in LevelStartParams startParams);
            
        void OnTrigger(string triggerId);
    }
}