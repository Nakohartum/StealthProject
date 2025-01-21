using _Root.Code.Input;
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

        public PlayerController(PlayerView playerView, InputController inputController, PlayerModel playerModel)
        {
            _playerView = playerView;
            _inputController = inputController;
            _inputController.OnMove += MovePlayer;
        }

        private void MovePlayer(Vector2 obj)
        {
            _playerView.transform.Translate(obj, Space.World);
        }
    }
}