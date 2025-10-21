using _Root.CleanCode.MovementFeature.Domain;
using _Root.CleanCode.Shared.Ports.Input;

namespace _Root.CleanCode.MovementFeature.Application
{
    public class ToggleStealthModeUsecase
    {
        private IInputPort _inputPort;
        private MovementState _movementState;

        public ToggleStealthModeUsecase(IInputPort inputPort, MovementState movementState)
        {
            _inputPort = inputPort;
            _movementState = movementState;
        }

        public void ToggleStealthMode()
        {
            if (_inputPort.ToggleStealthMode)
            {
                _movementState.IsInStealthMode = !_movementState.IsInStealthMode;
            }
        }
        
    }
}