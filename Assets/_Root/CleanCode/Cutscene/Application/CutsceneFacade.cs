using System;
using _Root.CleanCode.Cutscene.Domain;
using _Root.CleanCode.Shared.Ports.Cutscene;
using Cysharp.Threading.Tasks;

namespace _Root.CleanCode.Cutscene.Application
{
    /// <summary>
    /// Adapter that exposes the Cutscene feature as a Shared API (ICutsceneApi).
    /// Other features depend on this facade, not on Cutscene Domain.
    /// </summary>
    public sealed class CutsceneFacade : ICutscenePort
    {
        private readonly StartCutscene _start;
        private readonly SkipCutscene _skip;

        public CutsceneFacade(StartCutscene start, SkipCutscene skip)
        {
            _start = start;
            _skip = skip;
        }

        public bool IsPlaying { get; private set; }

        public event Action<string> OnStarted;
        public event Action<string> OnFinished;

        public async UniTask StartAsync(string cutsceneId)
        {
            if (IsPlaying) return;
            IsPlaying = true;
            try
            {
                await _start.ExecuteAsync(new CutsceneId(cutsceneId));
            }
            finally
            {
                IsPlaying = false;
            }
        }

        public void Skip() => _skip.Execute();

        // Internal raise helpers used by use cases
        internal void RaiseStarted(string id) => OnStarted?.Invoke(id);
        internal void RaiseFinished(string id) => OnFinished?.Invoke(id);
    }
}