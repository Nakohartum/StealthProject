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

        public PlayerController(PlayerView playerView, InputController inputController, PlayerModel playerModel, IMovable moveController)
        {
            _playerView = playerView;
            _inputController = inputController;
            _moveController = moveController;
            _inputController.OnMove += MovePlayer;
        }

        private void MovePlayer(Vector2 obj)
        {
            _moveController.Move(obj);
        }
    }
}