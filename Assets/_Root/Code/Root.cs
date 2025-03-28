using System;
using _Root.Code.Input;
using _Root.Code.LevelManager;
using _Root.Code.MainMenuFeature.MainMenuManager;
using _Root.Code.QuestFeature.Controller;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code
{
    public class Root : MonoBehaviour
    {
        [Inject] private MainMenuManager _menuManager;
        private void Start()
        {
            _menuManager.OpenMainMenu();
        }
    }
}