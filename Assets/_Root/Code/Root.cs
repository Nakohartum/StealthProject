using System;
using _Root.Code.LevelManager;
using _Root.Code.QuestFeature.Controller;
using _Root.Code.UI;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private GlobalManagers.LevelManager _levelManager;
        [Inject] private IFactory<PlayerView> _playerFactory;
        [SerializeField] private UIManager _uiManager;
        private void Start()
        {
            _playerFactory.Create();
            _levelManager.InitializeMainMenu();
            QuestManager.Instance.Initialize(_uiManager);
        }
    }
}