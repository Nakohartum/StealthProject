using System.Collections.Generic;

namespace _Root.CleanCode.QuestFeature.Infrastructure
{

    public interface ILevelEventPort
    {
        void Publish(string eventName, IReadOnlyDictionary<string, object> data = null);
    }
}