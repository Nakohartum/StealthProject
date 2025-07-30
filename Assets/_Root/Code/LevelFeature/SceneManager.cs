using System;
using _Root.Code.Miscellanious;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace _Root.Code.LevelFeature
{
    public class SceneManager
    {
        private string _currentScene = String.Empty;
        private LevelManager _levelManager;

        public SceneManager(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        public void SetCurrentScene(string sceneName)
        {
            _currentScene = sceneName;
        }


        public async UniTask ChangeSceneAsync(string sceneName, string spawnPointName = "default", LoadSceneMode sceneMode = LoadSceneMode.Single)
        {
            if (!_currentScene.Equals(String.Empty))
            {
                await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, sceneMode).ToUniTask();
                await UniTask.NextFrame();
                await UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(_currentScene);
                _currentScene = sceneName;
            }
            else
            {
                await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName,sceneMode).ToUniTask();
                _currentScene = sceneName;
            }
            
            await UniTask.NextFrame();
            await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneNames.UIScene, LoadSceneMode.Additive).ToUniTask();
            _levelManager.SetCurrentLevel();
            _levelManager.SpawnPlayer(spawnPointName);
            
        }
    }
}