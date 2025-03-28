using System;
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
        
        public class Factory : PlaceholderFactory<MainMenuView> { }
        
    }
}