using System;
using System.Collections.Generic;
using _Root.Code.DialogFeature.Model;
using _Root.Code.DialogFeature.SO;
using _Root.Code.DialogFeature.StateMachineDialog;
using _Root.Code.DialogFeature.View;
using _Root.Code.Input;
using UnityEngine;

namespace _Root.Code.DialogFeature.Presenter
{
    public class DialogPresenter : IDisposable
    {
        private DialogView _dialogView;
        private DialogModel _dialogModel;
        private InputController _inputController;
        public DialogStateMachine DialogStateMachine { get; private set; }
        public DialogPart CurrentDialogPart { get; private set; }

        public DialogPresenter(DialogView dialogView, DialogModel dialogModel, InputController inputController)
        {
            _dialogView = dialogView;
            _dialogModel = dialogModel;
            _inputController = inputController;
            DialogStateMachine = new DialogStateMachine(new Dictionary<DialogState, IDialogState>
            {
                { DialogState.Blinking, new BlinkingState(_dialogView, this)},
                { DialogState.Typing, new TypingState(this, _dialogView)},
                { DialogState.Done, new DoneState(_dialogView, this)}
            });
            _inputController.OnAnyKeyEntered += HandleInput;
        }

        private void HandleInput()
        {
            DialogStateMachine.HandleInput();
        }

        public void StartDialog()
        {
            _inputController.DisablePlayerMove();
            _inputController.DisableInteractionKey();
            CurrentDialogPart = _dialogModel.GetCurrentDialogPart();
            DialogStateMachine.ChangeState(DialogState.Typing);
        }
        

        public void ShowNextPart()
        {
            CurrentDialogPart = _dialogModel.GetCurrentDialogPart();
        }

        public void CloseDialog()
        {
            _inputController.EnablePlayerMove();
            _inputController.EnableInteractionKey();
            _inputController.DisableAnyKey();
            _dialogView.CloseDialog();
            Dispose();
        }

        public bool NextPartAvailable()
        {
            return _dialogModel.DialogPartsLeft();
        }

        public void Dispose()
        {
            _inputController.OnAnyKeyEntered -= HandleInput;
        }
    }
}