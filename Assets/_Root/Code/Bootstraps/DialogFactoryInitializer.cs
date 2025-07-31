using _Root.Code.DialogFeature.Factory;
using UnityEngine;
using Zenject;

namespace _Root.Code.Bootstraps
{
    public class DialogFactoryInitializer : IInitializable
    {
        private readonly DialogFactory _dialogFactory;
        private readonly Transform _root;

        public DialogFactoryInitializer(Transform root, DialogFactory dialogFactory)
        {
            _root = root;
            _dialogFactory = dialogFactory;
        }
        public void Initialize()
        {
            _dialogFactory.SetRoot(_root);
        }
    }
}