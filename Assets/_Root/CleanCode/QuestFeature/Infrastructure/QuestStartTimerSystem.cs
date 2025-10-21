using System;
using System.Collections.Generic;
using _Root.CleanCode.QuestFeature.Application;
using _Root.CleanCode.Shared.Ports;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.QuestFeature.Infrastructure
{
    public class QuestStartTimerSystem : ITickable, IInitializable, IDisposable
    {
        private readonly StartQuestUseCase _startQuest;
        private readonly List<ScriptableQuestStartRules> _ruleAssets;

        private readonly List<TimerEntry> _timers = new List<TimerEntry>(8);

        private struct TimerEntry
        {
            public string QuestId;
            public float Remaining;
            public float Period;
            public bool Repeat;
            public bool Active;
        }

        public QuestStartTimerSystem(
            StartQuestUseCase startQuest,
            List<ScriptableQuestStartRules> ruleAssets)
        {
            _startQuest = startQuest;
            _ruleAssets = ruleAssets ?? new List<ScriptableQuestStartRules>();
        }

        public void Initialize()
        {
            _timers.Clear();

            for (int a = 0; a < _ruleAssets.Count; a++)
            {
                var asset = _ruleAssets[a];
                if (asset == null || asset.Rules == null) continue;

                for (int i = 0; i < asset.Rules.Count; i++)
                {
                    var r = asset.Rules[i];
                    if (r.Trigger != ScriptableQuestStartRules.TriggerType.TimeElapsed) continue;
                    if (string.IsNullOrWhiteSpace(r.QuestId)) continue;

                    var delay = r.DelaySeconds <= 0f ? 0f : r.DelaySeconds;

                    _timers.Add(new TimerEntry
                    {
                        QuestId = r.QuestId,
                        Remaining = delay,
                        Period = delay,
                        Repeat = r.Repeat,
                        Active = true
                    });
                }
            }
        }

        public void Tick()
        {
            if (_timers.Count == 0) return;

            // Use ITime.DeltaTime to respect our abstraction (no UnityEngine.Time here)
            var dt = Time.deltaTime;
            if (dt <= 0f) return;

            for (int i = 0; i < _timers.Count; i++)
            {
                var t = _timers[i];
                if (!t.Active) continue;

                t.Remaining -= dt;
                if (t.Remaining <= 0f)
                {
                    TryStart(t.QuestId);

                    if (t.Repeat && t.Period > 0f)
                    {
                        // restart the timer
                        t.Remaining = t.Period;
                    }
                    else
                    {
                        t.Active = false; // one-shot: deactivate
                    }
                }

                _timers[i] = t;
            }
        }

        private void TryStart(string questId)
        {
            if (string.IsNullOrWhiteSpace(questId)) return;
            _startQuest.Execute(questId);
        }

        public void Dispose()
        {
            _timers.Clear();
        }
    }
}