using UnityEngine;

namespace _Root.Code.QuestFeature.Model
{
    public class QuestModel
    {
        public string Name;
        public QuestPart[] Parts;
        public bool Completed;

        public QuestModel(string name, QuestPart[] parts)
        {
            Name = name;
            Parts = parts;
        }

        public void CheckWhetherDine()
        {
            
            foreach (var part in Parts)
            {
                if (!part.IsDone)
                {
                    return;
                }
            }
            Debug.Log("Quest is done");
            Completed = true;
        }
    }
}