using System.Collections.Generic;
using _Root.CleanCode.QuestFeature.Infrastructure;
using _Root.CleanCode.Shared.Ports.Cutscene;
using Zenject;

namespace _Root.CleanCode.LevelFeature.Infrastructure
{
    public sealed class LevelSignalEventBus : ILevelEventPort
    {
        private readonly SignalBus _bus;

        public LevelSignalEventBus(SignalBus bus) { _bus = bus; }

        public void Publish(string eventName, IReadOnlyDictionary<string, object> data = null)
        {
            // Always fire generic for catch-all subscribers.
            _bus.Fire(new GenericLevelEventSignal(eventName, data));

            switch (eventName)
            {
                case "Level/Started":
                {
                    string levelId = data != null && data.TryGetValue("levelId", out var l) ? l as string : "Unknown";
                    _bus.Fire(new LevelStartedSignal(levelId));
                    break;
                }
                case "Cutscene/Play":
                {
                    string id = data != null && data.TryGetValue("cutsceneId", out var c) ? c as string : "";
                    _bus.Fire(new CutscenePlaySignal(id));
                    break;
                }
                case "Trigger/Reached":
                {
                    string levelId = data != null && data.TryGetValue("levelId", out var l) ? l as string : "Unknown";
                    string triggerId = data != null && data.TryGetValue("triggerId", out var t) ? t as string : "";
                    _bus.Fire(new TriggerReachedSignal(levelId, triggerId));
                    break;
                }
            }
        }
    }
}