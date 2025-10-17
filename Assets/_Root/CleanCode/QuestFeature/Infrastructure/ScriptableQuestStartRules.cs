using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Root.CleanCode.QuestFeature.Infrastructure
{
    [CreateAssetMenu(fileName = "QuestStartRules", menuName = "Create/Quests/QuestStartRule", order = 0)]
    public class ScriptableQuestStartRules : ScriptableObject
    {
        public enum TriggerType
        {
            CutsceneFinished = 0,
            DialogOptionChosen = 1,
            QuestCompleted = 2,
            /// <summary>Start after a delay measured in game time (uses ITime.DeltaTime).</summary>
            TimeElapsed = 3
        }

        [Serializable]
        public sealed class Rule
        {
            [Tooltip("Which signal to match.")]
            public TriggerType Trigger;

            [Tooltip("Quest ID to start when this rule matches.")]
            public string QuestId;

            [Header("Cutscene filter")]
            public string CutsceneId;

            [Header("Dialog filter")]
            public string DialogId;
            public string OptionId;

            [Header("Quest chaining filter")]
            public string DependsOnQuestId;

            [Header("Time trigger")]
            [Tooltip("Delay in seconds before starting the quest (game time).")]
            public float DelaySeconds = 0f;

            [Tooltip("If true, the rule repeats every DelaySeconds (infinite). If false, fires once.")]
            public bool Repeat;

            public override string ToString()
            {
                return $"{Trigger} -> start '{QuestId}'";
            }
        }

        [Tooltip("All start rules contained in this asset.")]
        public List<Rule> Rules = new List<Rule>();
    }
}