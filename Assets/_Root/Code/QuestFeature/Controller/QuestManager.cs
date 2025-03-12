using System;
using System.Collections.Generic;
using _Root.Code.LevelManager;
using _Root.Code.QuestFeature.Model;
using _Root.Code.UI;
using UnityEngine;
using Zenject;

namespace _Root.Code.QuestFeature.Controller
{
    public class QuestManager
    {
        private static QuestManager _instance;
        private List<QuestController> _activeQuests = new List<QuestController>();
        private QuestPartView _questPartViewPrefab;
        private UIManager _uiManager;
        
        [Inject]
        private QuestManager(QuestPartView questPartViewPrefab, UIManager uiManager)
        {
            _questPartViewPrefab = questPartViewPrefab;
            _uiManager = uiManager;
            _instance = this;
        }

        public static QuestManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public void StartQuest(QuestData questData)
        {
            var questView = _uiManager.CreateQuestView();
            var questController = new QuestController(CreateQuest(questData), questView, _questPartViewPrefab);
            questController.OnQuestCompleted += QuestFinished;
            _activeQuests.Add(questController);
            Debug.Log($"Started quest {questData.QuestName}");
        }

        private void QuestFinished(QuestController questController)
        {
            questController.Dispose();
            _activeQuests.Remove(questController);
        }

        private QuestModel CreateQuest(QuestData questData)
        {
            var questParts = CreateQuestParts(questData.QuestParts);
            var questModel = new QuestModel(questData.QuestName, questParts.ToArray());
            return questModel;
        }

        private List<QuestPart> CreateQuestParts(QuestPartData[] questDataQuestParts)
        {
            List<QuestPart> questParts = new List<QuestPart>();
            foreach (var questPartData in questDataQuestParts)
            {
                switch (questPartData.QuestType)
                {
                    case QuestType.LocationQuest:
                        questParts.Add(new LocationQuestPart(questPartData.Description, false, questPartData.TargetID));
                        break;
                    case QuestType.PickupQuest:
                        questParts.Add(new PickupQuestPart(questPartData.Description, false, questPartData.TargetID, questPartData.TargetAmount));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return questParts;
        }
    }
}