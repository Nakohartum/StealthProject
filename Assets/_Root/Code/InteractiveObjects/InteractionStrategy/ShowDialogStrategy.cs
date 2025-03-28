using _Root.Code.DialogFeature.Factory;
using _Root.Code.DialogFeature.Presenter;
using _Root.Code.DialogFeature.SO;
using Zenject;

namespace _Root.Code.InteractiveObjects.InteractionStrategy
{
    public class ShowDialogStrategy : IInteractionStrategy
    {
        [Inject] private IFactory<Dialog, DialogPresenter> _dialogFactory;
        private Dialog _dialog;

        public ShowDialogStrategy(Dialog dialog)
        {
            _dialog = dialog;
        }
        public void Interact()
        {
            var dialogPresenter = _dialogFactory.Create(_dialog);
            dialogPresenter.StartDialog();
        }
    }
}