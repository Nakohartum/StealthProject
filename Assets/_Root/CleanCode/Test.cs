using _Root.CleanCode.Shared.Ports.SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Root.CleanCode
{
    public class Test : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        
        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _sceneLoader.LoadSceneAsync("UIScene");
        }
    }
}