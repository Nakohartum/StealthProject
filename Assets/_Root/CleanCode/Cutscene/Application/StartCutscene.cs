using _Root.CleanCode.Cutscene.Domain;
using Cysharp.Threading.Tasks;

namespace _Root.CleanCode.Cutscene.Application
{
    /// <summary>Use case: start cutscene and await its completion.</summary>
    public sealed class StartCutscene
    {
        private readonly ICutscenePlayerPort _player;
        private readonly ICutsceneCatalogPort _catalog;
        private readonly CutsceneFacade _facade;

        public StartCutscene(ICutscenePlayerPort player, ICutsceneCatalogPort catalog, CutsceneFacade facade)
        {
            _player = player;
            _catalog = catalog;
            _facade = facade;
        }

        public async UniTask ExecuteAsync(CutsceneId id)
        {
            if (_player.IsPlaying) return;

            _facade.RaiseStarted(id.ToString());
            try
            {
                await _player.PlayAsync(id.Value);
            }
            finally
            {
                _facade.RaiseFinished(id.ToString());
            }
        }

        public bool CanSkip(CutsceneId id)
        {
            return _catalog.TryGetSkippable(id.Value, out var skippable) &&
                   CutscenePolicy.CanSkip(skippable);
        }
    }
}