using _Root.Code.Input;
using _Root.Code.MoveFeature;
using UniRx;
using UnityEngine;
using Zenject;

namespace GameOne.Player
{
    public class PlayerController
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private InputController _inputController;
        private IMovable _moveController;
        private int _isWalkingHash;
        private PlayerSoundsPlayer _playerSoundsPlayer;

        public PlayerController(PlayerView playerView, InputController inputController, 
            PlayerModel playerModel, IMovable moveController)
        {
            _playerView = playerView;
            _playerModel = playerModel;
            _inputController = inputController;
            _moveController = moveController;
            _playerSoundsPlayer = new PlayerSoundsPlayer(playerView.AudioSource, _playerModel.StepSounds);
            _isWalkingHash = Animator.StringToHash("IsWalking");
            _inputController.OnMove += MovePlayer;
            _inputController.OnMove += RotateTowardsMovingSide;
            _playerView.OnStepSoundPlay += _playerSoundsPlayer.PlayRandomStepSound;
        }

        private void MovePlayer(Vector2 obj)
        {
            _playerView.Animator.SetBool(_isWalkingHash, obj != Vector2.zero);
            _moveController.Move(obj);
        }

        private void RotateTowardsMovingSide(Vector2 obj)
        {
            float angle = Vector2.SignedAngle(_playerView.transform.up, obj);
            _playerView.transform.Rotate(0,0,angle);
        }
    }
}