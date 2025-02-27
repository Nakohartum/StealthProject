using System;
using System.Collections;
using _Root.Code.Miscellanious;
using _Root.Code.QuestFeature.Controller;
using _Root.Code.QuestFeature.Model;
using UnityEngine;

namespace _Root.Code.QuestFeature.View
{
    public class StartOverTimeQuest : MonoBehaviour
    {
        [field: SerializeField] public QuestData QuestData { get; private set; }
        [field: SerializeField] public EventInvoker EventInvoker { get; private set; }

        private void Start()
        {
            StartCoroutine(StartQuestOverTimeRoutine());
        }

        private IEnumerator StartQuestOverTimeRoutine()
        {
            yield return new WaitForSeconds(QuestData.StartTime);
            QuestManager.Instance.StartQuest(QuestData);
            EventInvoker.InvokeEvent();
        }
    }
}