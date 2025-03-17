using _Root.Code.UI;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code.UI.Dialog
{
    public class DialogViewCreator
    {
        private DialogView _dialogViewPrefab;
        private DialogView _dialogViewInstance;
        private SignalBus _signalBus;

        
        public DialogViewCreator(DialogView dialogViewPrefab, SignalBus signalBus)
        {
            _dialogViewPrefab = dialogViewPrefab;
            _signalBus = signalBus;
        }

        public DialogView CreateDialogView(Transform root)
        {
            if (_dialogViewInstance != null)
            {
                return _dialogViewInstance;
            }
            _dialogViewInstance = Object.Instantiate(_dialogViewPrefab, root);
            _signalBus.Fire(new DialogCreatedSignal
            {
                DialogView = _dialogViewInstance
            });
            _dialogViewInstance.gameObject.SetActive(false);
            return _dialogViewInstance;
        }

        public void DestroyDialogView()
        {
            if (_dialogViewInstance == null) return;
            Object.Destroy(_dialogViewInstance.gameObject);
            _dialogViewInstance = null;
        }
    }
    public class DialogCreatedSignal
    {
        public DialogView DialogView;
    }
}