using System;
using System.Collections;
using _Root.Code.Miscellanious;
using _Root.Code.QuestFeature.Controller;
using _Root.Code.QuestFeature.Model;
using UnityEngine;
using Zenject;

namespace _Root.Code.QuestFeature.View
{
    public class StartOverTimeQuest : MonoBehaviour
    {
        private QuestManager _questManager;
        [field: SerializeField] public QuestData QuestData { get; private set; }
        [field: SerializeField] public EventInvoker EventInvoker { get; private set; } = null;

        private void Start()
        {
            StartCoroutine(StartQuestOverTimeRoutine());
        }

        [Inject]
        public void Initialize(QuestManager questManager)
        {
            _questManager = questManager;
        }
        private IEnumerator StartQuestOverTimeRoutine()
        {
            yield return new WaitForSeconds(QuestData.StartTime);
            _questManager.StartQuest(QuestData);
            EventInvoker?.InvokeEvent();
        }
    }
}