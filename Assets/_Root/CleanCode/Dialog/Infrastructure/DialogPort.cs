using System;
using _Root.CleanCode.Dialog.Application;
using _Root.CleanCode.Dialog.Application.Ports;
using _Root.CleanCode.Dialog.Domain;
using _Root.CleanCode.Shared.Ports.Dialog;
using _Root.CleanCode.Shared.Ports.Input;
using Cysharp.Threading.Tasks;
using Shared._Root.CleanCode.Shared.Helper;
using Zenject;

namespace _Root.CleanCode.Dialog.Infrastructure
{
    public class DialogPort : IDialogPort, IInitializable
    {
        private StartDialogUseCase _startDialogUseCase;
        private TryProceedToNextLineUseCase _tryProceedToNextLineUseCase;
        private TypeNextLineUseCase _typeNextLineUseCase;
        private DialogState _dialogState;
        private DialogCatalog _dialogCatalog;
        private IDialogView _dialogView;
        private IInputPort _inputPort;
        private DialogPortProxy _dialogPortProxy;
        public event Action<string> OnDialogStarted;
        public event Action<string> OnDialogClosed;

        public DialogPort(StartDialogUseCase startDialogUseCase, TryProceedToNextLineUseCase tryProceedToNextLineUseCase, 
            TypeNextLineUseCase typeNextLineUseCase, DialogState dialogState, DialogCatalog dialogCatalog, IDialogView dialogView, IInputPort inputPort, DialogPortProxy proxy)
        {
            _startDialogUseCase = startDialogUseCase;
            _tryProceedToNextLineUseCase = tryProceedToNextLineUseCase;
            _typeNextLineUseCase = typeNextLineUseCase;
            _dialogState = dialogState;
            _dialogCatalog = dialogCatalog;
            _dialogView = dialogView;
            _inputPort = inputPort;
            _inputPort.OnDialogSkipPressed += delegate() { ProceedDialog().Forget(); };
            _dialogPortProxy =  proxy;
        }

        public void StartDialog(string name)
        {
            _dialogState.CurrentDialog = _dialogCatalog.FindDialog(name);
            _dialogState.IsPlaying = true;
            _inputPort.EnableInput(Strings.InputStrings.DialogInput);
            _dialogState.CurrentPartsIndex = 0;
            _dialogView.Show();
            _startDialogUseCase.StartDialog(_dialogState.CurrentDialog.Parts[_dialogState.CurrentPartsIndex]).Forget();
        }

        public void AddOnDialogStarted(Action<string> OnDialogStarted)
        {
            this.OnDialogStarted += OnDialogStarted;
        }

        public void AddOnDialogClosed(Action<string> OnDialogClosed)
        {
            this.OnDialogClosed += OnDialogClosed;
        }

        public async UniTask ProceedDialog()
        {
            if (_dialogState.IsTyping)
            {
                return;
            }
            _tryProceedToNextLineUseCase.HasOtherLinesToProceed(_dialogState.CurrentDialog);
            if (_dialogState.IsPlaying)
            {
                await _typeNextLineUseCase.TypeNextLine();
            }
            else
            {
                _dialogView.Hide();
            }
        }

        public void Initialize()
        {
            _dialogPortProxy.SetImplementation(this);
        }
    }
}