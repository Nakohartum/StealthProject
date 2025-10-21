using _Root.CleanCode.MovementFeature.Domain;
using _Root.CleanCode.Shared.Ports.Input;
using _Root.CleanCode.Shared.Ports.Move;
using Zenject;

namespace _Root.CleanCode.MovementFeature.Application
{
    public class MovementSystem 
    {
        private MovementModel _movementModel;
        private MovementState _movementState;
        private MoveUsecase _moveUsecase;
        private ToggleStealthModeUsecase _toggleStealthModeUsecase;
        private IMovePort _movePort;
        private IInputPort _inputPort;

        public MovementSystem(MovementModel movementModel, MovementState movementState, MoveUsecase moveUsecase, 
            ToggleStealthModeUsecase toggleStealthModeUsecase, IMovePort movePort, IInputPort inputPort)
        {
            _movementModel = movementModel;
            _movementState = movementState;
            _moveUsecase = moveUsecase;
            _toggleStealthModeUsecase = toggleStealthModeUsecase;
            _movePort = movePort;
            _inputPort = inputPort;
        }

        public void Tick()
        {
            _toggleStealthModeUsecase.ToggleStealthMode();
            _moveUsecase.GetMovementSpeed();
        }

        public void FixedTick()
        {
            _movePort.Move(_inputPort.MoveInput);
            _movePort.Rotate(_inputPort.MoveInput);
        }
    }
}