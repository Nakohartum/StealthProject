using System.Threading;
using _Root.CleanCode.Cutscene.Application;
using _Root.CleanCode.Shared.Ports;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;
using Zenject;

namespace _Root.CleanCode.Cutscene.Infrastructure
{
    /// <summary>
    /// Infrastructure player that loads a prefab (by id mapped via catalog) containing a PlayableDirector, plays it, then unloads.
    /// </summary>
    public sealed class TimelineCutscenePlayer : ICutscenePlayerPort, IInitializable
    {
        private readonly IAddressablesPort _addressables;
        private readonly ICutsceneCatalogRuntime _runtimeCatalog;
        private CancellationTokenSource _cts;
        private PlayableDirector _activeDirector;
        private GameObject _instance;
        private string _lastKey;

        public bool IsPlaying { get; private set; }

        [Inject]
        public TimelineCutscenePlayer(IAddressablesPort addressables, ICutsceneCatalogRuntime runtimeCatalog)
        {
            _addressables = addressables;
            _runtimeCatalog = runtimeCatalog;
        }

        public void Initialize()
        {
            // TODO: Optional warm-up
        }

        public async UniTask PlayAsync(string cutsceneId)
        {
            if (!_runtimeCatalog.TryResolveKey(cutsceneId, out var key))
                return;

            _lastKey = key;
            _cts = new CancellationTokenSource();
            IsPlaying = true;

            // Load prefab
            var prefab = await _addressables.LoadAsync<GameObject>(key);
            try
            {
                _instance = Object.Instantiate(prefab);
                _activeDirector = _instance.GetComponentInChildren<PlayableDirector>();
                if (_activeDirector == null)
                {
                    // No director found, stop immediately
                    return;
                }

                var tcs = new UniTaskCompletionSource();
                void OnStopped(PlayableDirector d) { tcs.TrySetResult(); }

                _activeDirector.stopped += OnStopped;
                _activeDirector.time = 0;
                _activeDirector.Play();

                using (_cts.Token.Register(() =>
                {
                    if (_activeDirector != null)
                    {
                        _activeDirector.time = _activeDirector.duration;
                        _activeDirector.Stop();
                    }
                    tcs.TrySetResult();
                }))
                {
                    await tcs.Task;
                }

                _activeDirector.stopped -= OnStopped;
            }
            finally
            {
                Cleanup();
                IsPlaying = false;
                if (prefab != null)
                {
                    await _addressables.UnloadAsync(prefab);
                }
            }
        }

        public void Stop()
        {
            _cts?.Cancel();
        }

        private void Cleanup()
        {
            if (_instance != null)
            {
                Object.Destroy(_instance);
                _instance = null;
            }
            _activeDirector = null;
            _cts?.Dispose();
            _cts = null;
            _lastKey = null;
        }
    }

    /// <summary>
    /// Runtime-facing catalog to resolve addressable keys for cutscenes.
    /// Separated from Application port to keep Unity types in Infrastructure only.
    /// </summary>
    public interface ICutsceneCatalogRuntime
    {
        bool TryResolveKey(string cutsceneId, out string addressableKey);
    }

}