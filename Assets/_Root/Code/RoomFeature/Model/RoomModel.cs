using System;
using UnityEngine;

namespace _Root.Code.RoomFeature.Model
{
    public class RoomModel
    {
        private bool _isPlayerIn;
        public event Action<bool> OnPlayerMovedThroughTheRoom;

        public void PlayerEnteredRoom()
        {
            _isPlayerIn = true; 
            OnPlayerMovedThroughTheRoom?.Invoke(_isPlayerIn);
        }

        public void PlayerLeftRoom()
        {
            _isPlayerIn = false;
            OnPlayerMovedThroughTheRoom?.Invoke(_isPlayerIn);
        }
    }
}