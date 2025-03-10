using _Root.Code.UI;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code.LevelManager
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

        public void CreateDialogView(Transform root)
        {
            if (_dialogViewInstance != null)
            {
                return;
            }
            _dialogViewInstance = Object.Instantiate(_dialogViewPrefab, root);
            _signalBus.Fire(new DialogCreatedSignal
            {
                DialogView = _dialogViewInstance
            });
            _dialogViewInstance.gameObject.SetActive(false);
        }

        public void DestroyDialogView()
        {
            if (_dialogViewInstance == null) return;
            Object.Destroy(_dialogViewInstance.gameObject);
            _dialogViewInstance = null;
        }
    }
}