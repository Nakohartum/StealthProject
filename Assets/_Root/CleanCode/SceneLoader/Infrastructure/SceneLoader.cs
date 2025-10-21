using System.Collections.Generic;
using _Root.CleanCode.Shared.Ports.SceneLoader;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Root.CleanCode.SceneLoader.Infrastructure
{
    public class SceneLoader : ISceneLoader
    {
        private ZenjectSceneLoader _zenjectSceneLoader;
        private readonly HashSet<string> _persistent = new HashSet<string>(8);
        
        public string ActiveScene => SceneManager.GetActiveScene().IsValid() ? SceneManager.GetActiveScene().name : null;
        public string[] LoadedScenes
        {
            get
            {
                var list = new List<string>(SceneManager.sceneCount);
                for (int i = 0; i < SceneManager.sceneCount; i++)
                    list.Add(SceneManager.GetSceneAt(i).name);
                return list.ToArray();
            }
        }

        public SceneLoader(ZenjectSceneLoader zenjectSceneLoader, IEnumerable<string> persistent)
        {
            _zenjectSceneLoader = zenjectSceneLoader;
            foreach (var s in persistent)
            {
                if (!string.IsNullOrWhiteSpace(s))
                    _persistent.Add(s);
            }
        }
        public async UniTask LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive, LoadSceneRelationship relationship = LoadSceneRelationship.Child, bool setActive = true)
        {
            if (string.IsNullOrWhiteSpace(sceneName)) return;
            if (SceneManager.GetSceneByName(sceneName).isLoaded) // already loaded
            {
                if (setActive)
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
                return;
            }

            await _zenjectSceneLoader.LoadSceneAsync(sceneName, mode, extraBindings: null, relationship).ToUniTask();;

            if (setActive)
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }

        public async UniTask UnloadSceneAsync(string sceneName)
        {
            if (string.IsNullOrWhiteSpace(sceneName)) return;
            var sc = SceneManager.GetSceneByName(sceneName);
            if (!sc.isLoaded) return;
            

            if (_persistent.Contains(sceneName)) return;

            // Don't unload active scene outright (call SwitchToAsync instead)
            if (sc == SceneManager.GetActiveScene()) return;

            await SceneManager.UnloadSceneAsync(sceneName);
        }

        public async UniTask SwitchToAsync(string sceneName, bool setActive = true)
        {
            if (string.IsNullOrWhiteSpace(sceneName)) return;

            await LoadSceneAsync(sceneName, setActive: setActive);

            var toUnload = new List<string>(SceneManager.sceneCount);
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var s = SceneManager.GetSceneAt(i);
                if (!s.isLoaded) continue;
                var name = s.name;

                if (name == sceneName) continue;
                if (_persistent.Contains(name)) continue;

                toUnload.Add(name);
            }

            foreach (var n in toUnload)
            {
                await SceneManager.UnloadSceneAsync(n);
            }

            if (setActive)
            {
                var target = SceneManager.GetSceneByName(sceneName);
                if (target.IsValid())
                    SceneManager.SetActiveScene(target);
            }
        }

    }
}