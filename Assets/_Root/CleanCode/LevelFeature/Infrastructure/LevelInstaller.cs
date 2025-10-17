using _Root.CleanCode.LevelFeature.Application;
using _Root.CleanCode.QuestFeature.Infrastructure;
using Zenject;

namespace _Root.CleanCode.LevelFeature.Infrastructure
{
    public sealed class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILevelEventPort>().To<LevelSignalEventBus>().AsSingle();

            Container.Bind<ILevelControl>().To<LevelDirector>().AsSingle();
        }
    }
}