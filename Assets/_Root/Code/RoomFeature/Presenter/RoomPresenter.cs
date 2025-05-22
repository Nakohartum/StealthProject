using System;
using _Root.Code.RoomFeature.Model;
using _Root.Code.RoomFeature.View;
using Zenject;

namespace _Root.Code.RoomFeature.Presenter
{
    public class RoomPresenter
    {
        private RoomModel _roomModel;
        private RoomView _roomView;

        [Inject]
        public RoomPresenter(RoomModel roomModel, RoomView roomView)
        {
            _roomModel = roomModel;
            _roomView = roomView;
            _roomView.OnRoomWentThrough += ChangeRoomStatus;
        }

        private void ChangeRoomStatus(bool obj)
        {
            if (obj)
            {
                _roomModel.PlayerEnteredRoom();
            }
            else
            {
                _roomModel.PlayerLeftRoom();
            }
        }

        public void SubscribeToRoomWentThrough(Action<bool> callback)
        {
            _roomModel.OnPlayerMovedThroughTheRoom += callback;
        }

        public RoomModel GetRoomModel()
        {
            return _roomModel;
        }

        public RoomView GetRoomView()
        {
            return _roomView;
        }
    }
}