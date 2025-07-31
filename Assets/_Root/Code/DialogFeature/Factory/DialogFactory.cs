using System.Collections.Generic;
using _Root.Code.DialogFeature.Model;
using _Root.Code.DialogFeature.Presenter;
using _Root.Code.DialogFeature.SO;
using _Root.Code.DialogFeature.StateMachineDialog;
using _Root.Code.DialogFeature.View;
using _Root.Code.Input;
using UnityEngine;
using Zenject;

namespace _Root.Code.DialogFeature.Factory
{
    public class DialogFactory : IFactory<Dialog, DialogPresenter>
    {
        private DialogView _dialogViewPrefab;
        private DiContainer _container;
        private Transform _root;
        private InputController _inputController;
        public DialogFactory(DiContainer container, DialogView dialogViewPrefab, InputController inputController)
        {
            _container = container;
            _dialogViewPrefab = dialogViewPrefab;
            _inputController = inputController;
        }

        public void SetRoot(Transform root)
        {
            _root = root;
        }
        
        public DialogPresenter Create(Dialog dialog)
        {
            Debug.Log("Created dialog");
            var model = new DialogModel(dialog);
                var view = _container.InstantiatePrefabForComponent<DialogView>(_dialogViewPrefab, _root);
            var presenter = new DialogPresenter(view, model, _inputController);
            view.Initialize(presenter);
            return presenter;
        }
    }
}