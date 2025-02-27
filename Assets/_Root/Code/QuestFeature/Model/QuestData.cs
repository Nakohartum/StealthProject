using System;
using UnityEngine;

namespace _Root.Code.QuestFeature.Model
{
    [CreateAssetMenu(fileName = nameof(QuestData), menuName = "Create/Quest/"+nameof(QuestData), order = 0)]
    public class QuestData : ScriptableObject
    {
        public string QuestName;
        public float StartTime;
        public QuestPartData[] QuestParts;
    }

    [Serializable]
    public class QuestPartData
    {
        public QuestType QuestType;
        public string Description;
        public string TargetID;
        public int TargetAmount;
    }

    public enum QuestType
    {
        LocationQuest,
        PickupQuest
    }
}