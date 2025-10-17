using System;
using System.Collections.Generic;
using System.Linq;
using _Root.CleanCode.QuestFeature.Application;
using _Root.CleanCode.Shared.Ports.Cutscene;
using _Root.CleanCode.Shared.Ports.Dialog;
using _Root.CleanCode.Shared.Ports.Quests;
using Zenject;

namespace _Root.CleanCode.QuestFeature.Infrastructure
{
    public class QuestStartByRuleSystem : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly StartQuestUseCase _startQuestUseCase;
        private readonly List<ScriptableQuestStartRules> _rules;

        private readonly List<ScriptableQuestStartRules.Rule> _cutsceneRules;
        private readonly List<ScriptableQuestStartRules.Rule> _dialogRules;
        private readonly List<ScriptableQuestStartRules.Rule> _chainRules;

        public QuestStartByRuleSystem(SignalBus signalBus, StartQuestUseCase startQuestUseCase, List<ScriptableQuestStartRules> rules)
        {
            _signalBus = signalBus;
            _startQuestUseCase = startQuestUseCase;
            _rules = rules;
        }

        public void Initialize()
        {
            var all = _rules.SelectMany(a => a.Rules ?? Enumerable.Empty<ScriptableQuestStartRules.Rule>());
            foreach (var r in all)
            {
                switch (r.Trigger)
                {
                    case ScriptableQuestStartRules.TriggerType.CutsceneFinished: _cutsceneRules.Add(r); break;
                    case ScriptableQuestStartRules.TriggerType.DialogOptionChosen: _dialogRules.Add(r); break;
                    case ScriptableQuestStartRules.TriggerType.QuestCompleted: _chainRules.Add(r); break;
                }
            }

            _signalBus.Subscribe<CutsceneFinishedSignal>(OnCutsceneFinished);
            _signalBus.Subscribe<DialogOptionChosenSignal>(OnDialogOptionChosen);
            _signalBus.Subscribe<QuestCompletedSignal>(OnQuestCompleted);
        }
        
        private void OnCutsceneFinished(CutsceneFinishedSignal sig)
        {
            if (string.IsNullOrEmpty(sig.CutsceneId)) return;

            for (int i = 0; i < _cutsceneRules.Count; i++)
            {
                var r = _cutsceneRules[i];
                if (!string.IsNullOrEmpty(r.CutsceneId) &&
                    !string.Equals(r.CutsceneId, sig.CutsceneId, StringComparison.Ordinal))
                    continue;

                TryStart(r.QuestId);
            }
        }

        private void OnDialogOptionChosen(DialogOptionChosenSignal sig)
        {
            for (int i = 0; i < _dialogRules.Count; i++)
            {
                var r = _dialogRules[i];
                if (!string.IsNullOrEmpty(r.DialogId) &&
                    !string.Equals(r.DialogId, sig.DialogId, StringComparison.Ordinal))
                    continue;
                if (!string.IsNullOrEmpty(r.OptionId) &&
                    !string.Equals(r.OptionId, sig.OptionId, StringComparison.Ordinal))
                    continue;

                TryStart(r.QuestId);
            }
        }

        private void OnQuestCompleted(QuestCompletedSignal sig)
        {
            foreach (var r in _chainRules.Where(r => string.IsNullOrEmpty(r.DependsOnQuestId) ||
                                                     string.Equals(r.DependsOnQuestId, sig.Id, StringComparison.Ordinal)))
            {
                TryStart(r.QuestId);
            }
        }

        private void TryStart(string questId)
        {
            if (string.IsNullOrWhiteSpace(questId)) return;
            _startQuestUseCase.Execute(questId);
        }

        public void Dispose()
        {
            _signalBus.TryUnsubscribe<CutsceneFinishedSignal>(OnCutsceneFinished);
            _signalBus.TryUnsubscribe<DialogOptionChosenSignal>(OnDialogOptionChosen);
            _signalBus.TryUnsubscribe<QuestCompletedSignal>(OnQuestCompleted);
            
        }
    }
    
}