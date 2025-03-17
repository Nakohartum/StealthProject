using System;
using System.Collections.Generic;
using _Root.Code.Miscellanious;
using _Root.Code.QuestFeature.Model;
using _Root.Code.UI;
using ModestTree.Util;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Root.Code.QuestFeature.Controller
{
    public class QuestController : IDisposable
    {
        private QuestModel _questModel;
        private QuestView _questView;
        private UIManager _uiManager;
        private List<QuestPartView> _currentQuestParts = new List<QuestPartView>();
        public event Action<QuestController> OnQuestCompleted;

        public QuestController(QuestModel questModel, QuestView questView, 
            UIManager uiManager)
        {
            _questModel = questModel;
            _questView = questView;
            _uiManager = uiManager;
            InitializeQuestView();
            SubscribeToEvent();
        }

        private void InitializeQuestView()
        {
            _questView.SetTitle(_questModel.Name);
            for (int i = 0; i < _questModel.Parts.Length; i++)
            {
                var questPartView = _uiManager.CreateQuestPartView(_questView.QuestPartsContainer);
                _currentQuestParts.Add(questPartView);
                UpdateQuestPartView(questPartView, _questModel.Parts[i]);
            }
        }

        private void UpdateQuestView()
        {
            for (int i = 0; i < _questModel.Parts.Length; i++)
            {
                UpdateQuestPartView(_currentQuestParts[i], _questModel.Parts[i]);
            }
        }
        
        private void UpdateQuestPartView(QuestPartView questPartView, QuestPart questPart)
        {
            questPartView.SetQuestPartCompleted(questPart.IsDone);
            questPartView.SetQuestPartName(questPart.Description);
            if (questPart is PickupQuestPart pickupQuestPart)
            {
                questPartView.SetQuestPartProgress($"{pickupQuestPart.CurrentAmount}/{pickupQuestPart.TargetAmount}");
            }
            else
            {
                questPartView.SetQuestPartProgress(string.Empty);
            }
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
                Object.Destroy(_questView.gameObject);
            }
            UpdateQuestView();
        }

        public void Dispose()
        {
            EventBus.OnLocationAchieved -= LocationAchieved;
            OnQuestCompleted = null;
        }
    }
}