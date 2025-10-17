using System.Collections.Generic;

namespace _Root.CleanCode.QuestFeature.Infrastructure
{
    public readonly struct LevelStartedSignal
    {
        public readonly string LevelId;
        public LevelStartedSignal(string levelId) { LevelId = levelId; }
    }

    public readonly struct TriggerReachedSignal
    {
        public readonly string LevelId;
        public readonly string TriggerId;
        public TriggerReachedSignal(string levelId, string triggerId)
        { LevelId = levelId; TriggerId = triggerId; }
    }

    public readonly struct GenericLevelEventSignal
    {
        public readonly string Event;
        public readonly IReadOnlyDictionary<string, object> Data;
        public GenericLevelEventSignal(string evt, IReadOnlyDictionary<string, object> data)
        { Event = evt; Data = data; }
    }
}