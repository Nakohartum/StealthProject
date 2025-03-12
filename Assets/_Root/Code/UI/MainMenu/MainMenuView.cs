using System;
using _Root.Code.CutsceneFeature.Controller;
using _Root.Code.GlobalManagers;
using _Root.Code.Miscellanious;
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
        

        private void Start()
        {
            GlobalMusicManager.Instance.StartAudioByName(InGameStrings.MAIN_MENU_MUSIC, true);
            _playButton.Button.onClick.AddListener(StartGame);
            _exitButton.Button.onClick.AddListener(ExitGame);
        }

        private void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void StartGame()
        { 
            GlobalManagers.LevelManager.Instance.InitLevel(InGameStrings.FIRST_LEVEL);
            GlobalMusicManager.Instance.StopMusic();
        }

        private void OnDestroy()
        {
            _playButton.Button.onClick.RemoveAllListeners();
            _exitButton.Button.onClick.RemoveAllListeners();
            _settingsButton.Button.onClick.RemoveAllListeners();
        }
    }
}