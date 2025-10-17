using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Root.CleanCode.Shared.Ports.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive, LoadSceneRelationship relationship = LoadSceneRelationship.Child, bool setActive = true);
        
        UniTask UnloadSceneAsync(string sceneName);
        UniTask SwitchToAsync(string sceneName, bool setActive = true);

        /// <summary>Current active scene name (null if unknown).</summary>
        string ActiveScene { get; }

        /// <summary>Snapshot of currently loaded scene names.</summary>
        string[] LoadedScenes { get; }
    }
}