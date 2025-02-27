using System;
using _Root.Code.Miscellanious;
using _Root.Code.QuestFeature.Model;
using ModestTree.Util;
using UnityEngine;

namespace _Root.Code.QuestFeature.Controller
{
    public class QuestController : IDisposable
    {
        private QuestModel _questModel;
        public event Action<QuestController> OnQuestCompleted;

        public QuestController(QuestModel questModel)
        {
            _questModel = questModel;
            SubscribeToEvent();
        }

        private void SubscribeToEvent()
        {
            EventBus.OnLocationAchieved += LocationAchieved;
            EventBus.OnItemPickedUp += ItemPicked;
        }

        private void ItemPicked(string obj)
        {
            foreach (var part in _questModel.Parts)
            {
                if (part is PickupQuestPart)
                {
                    part.CheckWhetherDone(obj);
                }
            }
            CheckQuestCompleted();
            Debug.Log("PickedUp");
        }

        private void LocationAchieved(string obj)
        {
            foreach (var part in _questModel.Parts)
            {
                if (part is LocationQuestPart)
                {
                    part.CheckWhetherDone(obj);
                }
            }
            CheckQuestCompleted();
            Debug.Log("LocationAchieved");
        }

        private void CheckQuestCompleted()
        {
            _questModel.CheckWhetherDine();
            if (_questModel.Completed)
            {
                OnQuestCompleted?.Invoke(this);
            }
        }

        public void Dispose()
        {
            EventBus.OnLocationAchieved -= LocationAchieved;
            OnQuestCompleted = null;
        }
    }
}