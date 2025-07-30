using _Root.Code.DialogFeature.Factory;
using _Root.Code.DialogFeature.Presenter;
using _Root.Code.DialogFeature.SO;
using _Root.Code.QuestFeature;
using _Root.Code.QuestFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.Bootstraps
{
    public class UIBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform _root;

        [Inject] private DialogFactory _dialogFactory;
        [Inject] private QuestViewFactory _questViewFactory;

        public void Initialize()
        {
            _dialogFactory.SetRoot(_root);
            _questViewFactory.SetRoot(_root);
        }
    }
}