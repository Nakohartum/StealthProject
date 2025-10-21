using System.Collections.Generic;
using _Root.CleanCode.LevelFeature.Domain;
using _Root.CleanCode.QuestFeature.Infrastructure;

namespace _Root.CleanCode.LevelFeature.Application
{
    public sealed class LevelDirector : ILevelControl
    {
        private readonly ILevelEventPort _events;
        private bool _started;
        private string _levelId = "Unknown";

        public LevelDirector(ILevelEventPort events)
        {
            _events = events;
        }

        public void StartLevel(in LevelStartParams startParams)
        {
            if (_started) return;
            _started = true;
            _levelId = string.IsNullOrWhiteSpace(startParams.LevelId) ? "Unknown" : startParams.LevelId;

            _events.Publish("Level/Started", new Dictionary<string, object>
            {
                ["levelId"] = _levelId
            });

            if (startParams.AutoStartEvents != null)
            {
                for (int i = 0; i < startParams.AutoStartEvents.Length; i++)
                {
                    var evt = startParams.AutoStartEvents[i];
                    if (!string.IsNullOrWhiteSpace(evt))
                        _events.Publish(evt, null);
                }
            }

            if (!string.IsNullOrWhiteSpace(startParams.InitialCutsceneId))
            {
                _events.Publish("Cutscene/Play", new Dictionary<string, object>
                {
                    ["cutsceneId"] = startParams.InitialCutsceneId
                });
            }
        }
        

        public void OnTrigger(string triggerId)
        {
            if (!_started || string.IsNullOrWhiteSpace(triggerId)) return;

            _events.Publish("Trigger/Reached", new Dictionary<string, object>
            {
                ["levelId"] = _levelId,
                ["triggerId"] = triggerId
            });
        }

       
    }
}