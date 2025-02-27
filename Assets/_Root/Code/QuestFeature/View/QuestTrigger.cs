using System;
using _Root.Code.QuestFeature.Controller;
using _Root.Code.QuestFeature.Model;
using UnityEngine;

namespace _Root.Code.QuestFeature.View
{
    public class QuestTrigger : MonoBehaviour
    {
        public QuestData QuestData;

        private void OnTriggerEnter2D(Collider2D other)
        {
            QuestManager.Instance.StartQuest(QuestData);
        }
    }
}