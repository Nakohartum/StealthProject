using System;
using _Root.Code.QuestFeature.Controller;
using _Root.Code.QuestFeature.Model;
using UnityEngine;
using Zenject;

namespace _Root.Code.QuestFeature.View
{
    public class QuestTrigger : MonoBehaviour
    {
        public QuestData QuestData;
        private QuestManager _questManager;

        [Inject]
        public void Initialize(QuestManager questManager)
        {
            _questManager = questManager;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _questManager.StartQuest(QuestData);
        }
    }
}