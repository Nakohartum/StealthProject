using _Root.CleanCode.InteractableFeature.Domain;

namespace _Root.CleanCode.InteractableFeature.Application
{
    public class ToggleInteractionStyleUseCase
    {
        private readonly InteractableObjectState _state;

        public ToggleInteractionStyleUseCase(InteractableObjectState state)
        {
            _state = state;
        }

        public bool SetInteractionStyle(bool on)
        {
            if (_state.IsHighlighted == on)
            {
                return _state.IsHighlighted;
            }
            _state.IsHighlighted = on;
            return _state.IsHighlighted;
        }
    }
}