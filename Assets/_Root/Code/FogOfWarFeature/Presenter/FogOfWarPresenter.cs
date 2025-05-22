using _Root.Code.FogOfWarFeature.Components;
using _Root.Code.RoomFeature.Presenter;
using Zenject;

namespace _Root.Code.FogOfWarFeature.Presenter
{
    public class FogOfWarPresenter
    {
        private FogOfWar _fogOfWar;
        private RoomPresenter _roomPresenter;

        [Inject]
        public FogOfWarPresenter(FogOfWar fogOfWar, RoomPresenter roomPresenter)
        {
            _fogOfWar = fogOfWar;
            _roomPresenter = roomPresenter;
            _roomPresenter.SubscribeToRoomWentThrough(ToggleFogOfWar);
        }

        private void ToggleFogOfWar(bool obj)
        {
            if (obj)
            {
                _fogOfWar.FogOfWarStop();
            }
            else
            {
                _fogOfWar.FogOfWarStart();
            }
        }
    }
}