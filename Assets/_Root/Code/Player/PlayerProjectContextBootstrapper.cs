using Zenject;

namespace GameOne.Player
{
    public class PlayerProjectContextBootstrapper : IInitializable
    {
        private readonly PlayerProjectContextFactory _factory;

        public PlayerProjectContextBootstrapper(PlayerProjectContextFactory factory)
        {
            _factory = factory;
        }
        public void Initialize()
        {
            _factory.Create();
        }
    }
}