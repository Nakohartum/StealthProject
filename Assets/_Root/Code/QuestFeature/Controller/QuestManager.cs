using System;
using System.Collections.Generic;
using _Root.Code.QuestFeature.Model;
using _Root.Code.QuestFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.QuestFeature.Controller
{
    public class QuestManager
    {
        private List<QuestController> _activeQuests = new List<QuestController>();
        private IFactory<QuestView> _questViewFactory;
        private DiContainer _container;
        
        [Inject]
        private QuestManager(IFactory<QuestView> questViewFactory, DiContainer container)
        {
            _questViewFactory = questViewFactory;
            _container = container;
        }

        public void StartQuest(QuestData questData)
        {
            var questView = _questViewFactory.Create();
            var questController = _container.Instantiate<QuestController>(new object[] {CreateQuest(questData), questView});
            questController.StartQuest();
            questController.OnQuestCompleted += QuestFinished;
            _activeQuests.Add(questController);
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