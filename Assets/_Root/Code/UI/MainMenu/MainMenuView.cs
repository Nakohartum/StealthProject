using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Root.Code.UI.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private HoverTextButton _playButton;
        [SerializeField] private HoverTextButton _settingsButton;
        [SerializeField] private HoverTextButton _exitButton;
        private GlobalManagers.LevelManager _levelManager;
        
        [Inject]
        public void Initialize(GlobalManagers.LevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        private void Start()
        {
            _playButton.Button.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            GlobalManagers.LevelManager.Instance.InitLevel("HomeLevel");
        }
    }
}