using System;
using _Root.Code.RoomFeature.Presenter;
using UnityEngine;

namespace _Root.Code.RoomFeature.View
{
    public class RoomView : MonoBehaviour
    {
        public event Action<bool> OnRoomWentThrough;

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnRoomWentThrough?.Invoke(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnRoomWentThrough?.Invoke(false);
        }
    }
}