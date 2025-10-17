using System;
using _Root.CleanCode.MovementFeature.Domain;
using _Root.CleanCode.Shared.Ports.Input;

namespace _Root.CleanCode.MovementFeature.Application
{
    public class MoveUsecase
    {
        private MovementState _movementState;
        private MovementModel _movementModel;
        private IInputPort _inputPort;

        public MoveUsecase(MovementState movementState, MovementModel movementModel, IInputPort inputPort)
        {
            _movementState = movementState;
            _movementModel = movementModel;
            _inputPort = inputPort;
        }

        public void GetMovementSpeed()
        {
            if (_movementState.IsMoving && _inputPort.MoveInput.SqrMagnitude < 0.1f)
            {
                _movementState.CurrentMovementSpeed = _movementModel.Deceleration;
                return;
            }

            if (_inputPort.MoveInput.SqrMagnitude > 0.1f)
            {
                if (_movementState.IsInStealthMode)
                {
                    _movementState.CurrentMovementSpeed = _movementModel.Acceleration;
                    _movementState.MaxSpeed = _movementModel.SpeedInStealthMode;
                }
                else
                {
                    _movementState.CurrentMovementSpeed = _movementModel.Acceleration;
                    _movementState.MaxSpeed = _movementModel.MaxSpeed;
                }
            }
        }
    }
}