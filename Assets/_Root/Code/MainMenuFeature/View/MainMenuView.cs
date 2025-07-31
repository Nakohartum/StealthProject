using System;
using _Root.Code.MainMenuFeature.Presenter;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Root.Code.MainMenuFeature.View
{
    public class MainMenuView : MonoBehaviour
    {
        [field:SerializeField] public HoverTextButton StartGameButton { get; private set; }
        [field:SerializeField] public HoverTextButton SettingsButton{ get; private set; }
        [field:SerializeField] public HoverTextButton ExitGameButton{ get; private set; }
        
        public MainMenuPresenter MainMenuPresenter { get; private set; }

        public void InitializeView(MainMenuPresenter presenter)
        {
            MainMenuPresenter = presenter;
        }

        private void OnDestroy()
        {
            MainMenuPresenter.Dispose();
        }
    }
}