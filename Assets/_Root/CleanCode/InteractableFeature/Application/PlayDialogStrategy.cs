using _Root.CleanCode.InteractableFeature.Application.Ports;
using _Root.CleanCode.InteractableFeature.Domain;
using _Root.CleanCode.Shared.Ports.Dialog;

namespace _Root.CleanCode.InteractableFeature.Application
{
    public class PlayDialogStrategy : IInteractionStrategy
    {
        private InteractableModel _model;
        private IDialogPort _dialogPort;
        
        public PlayDialogStrategy(InteractableModel model, IDialogPort dialogPort)
        {
            _model = model;
            _dialogPort = dialogPort;
        }

        public void Interact()
        {
            _dialogPort.StartDialog(_model.DialogKey);
        }

        public void Initialize()
        {
            
        }
    }
}