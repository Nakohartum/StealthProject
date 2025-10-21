using System;
using System.Collections.Generic;
using _Root.CleanCode.QuestFeature.Domain;
using _Root.CleanCode.QuestFeature.Domain.QuestTypes;
using UnityEngine;

namespace _Root.CleanCode.QuestFeature.Infrastructure
{
    [CreateAssetMenu(fileName = "QuestConfig", menuName = "Create/Quests/Quest", order = 0)]
    public class ScriptableQuestConfig : ScriptableObject
    {
        [Serializable]
        public class ObjectiveDef
        {
            public string Id;
            public QuestType Type;
            public string Description;
            public string ItemId;
            public string TargetId;
            public int Count = 1;
        }
        
        [Header("Identity")]
        public string QuestId;
        public string Title;
        [TextArea] public string Description;

        [Header("Objectives")]
        public List<ObjectiveDef> Objectives = new List<ObjectiveDef>();

        /// <summary>Create domain aggregate from this config.</summary>
        public Quest ToDomain()
        {
            var list = new List<Objective>(Objectives.Count);
            foreach (var o in Objectives)
            {
                switch (o.Type)
                {
                    case QuestType.Collect:
                        list.Add(new CollectObjective(o.Id, o.ItemId, o.Description, Math.Max(1, o.Count)));
                        break;
                    case QuestType.Deliver:
                        list.Add(new DeliverObjective(o.Id, o.ItemId, o.TargetId, o.Description,Math.Max(1, o.Count)));
                        break;
                    case QuestType.Kill:
                        list.Add(new KillObjective(o.Id, o.TargetId, o.Description, Math.Max(1, o.Count)));
                        break;
                    case QuestType.Reach:
                        list.Add(new ReachObjective(o.Id, o.TargetId, o.Description, Math.Max(1, o.Count)));
                        break;
                }
            }

            return new Quest(QuestId, string.IsNullOrWhiteSpace(Title) ? QuestId : Title, Description ?? string.Empty, list);
        }
    }
}