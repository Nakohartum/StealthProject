using System;
using _Root.CleanCode.Shared.Ports.Player;
using _Root.CleanCode.Shared.Ports.Room;
using UnityEngine;

namespace _Root.CleanCode.Room.Infrastructure
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class RoomAdapter : MonoBehaviour, IRoomPort
    {
        public event Action<bool> OnPlayerEnteredRoom;
        public event Action<bool> OnPlayerLeftRoom;
        [SerializeField] private Fog _fog;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<IPlayerTag>(out var _))
            {
                Debug.Log("Disabling fog");
                return;
            }

            if (_fog != null)
            {
                
                _fog.DisableFog();
            }
            OnPlayerEnteredRoom?.Invoke(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent<IPlayerTag>(out var _))
            {
                return;
            }
            if (_fog != null)
            {
                _fog.EnableFog();
            }
            OnPlayerLeftRoom?.Invoke(true);
        }
    }
}