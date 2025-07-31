using _Root.Code.Signals;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code.LevelFeature
{
    public class LevelManager
    {
        private IFactory<Transform, PlayerView> _playerFactory;

        private Level _currentLevel;

        public void SetCurrentLevel()
        {
            _currentLevel = Object.FindObjectOfType<Level>();
        }

        public void SpawnPlayer(string spawnPointName)
        {
            var spawnPoint = _currentLevel.GetSpawnPoint(spawnPointName);
            _playerFactory.Create(spawnPoint.transform);
        }

        public void OnPlayerFactoryReady(PlayerFactoryCreatedSignal obj)
        {
            _playerFactory = obj.PlayerFactory;
        }
    }
}