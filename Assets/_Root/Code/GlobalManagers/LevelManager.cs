using System.Linq;
using _Root.Code.LevelManager;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code.GlobalManagers
{
    public class LevelManager
    {
        private PlayerView _playerView;
        [Inject] private LevelSO[] _levels;
        [Inject] private Transform _levelsRoot;
        public LevelSO CurrentLevel {get; private set;}
        public Level CurrentLevelObject {get; private set;}

        [Inject]
        public void Initialize(SignalBus signalBus)
        {
            signalBus.Subscribe<PlayerCreatedSignal>(OnPlayerCreated);
        }

        private void OnPlayerCreated(PlayerCreatedSignal obj)
        {
            _playerView = obj.PlayerView;
        }

        public void DestroyLevel()
        {
            Object.Destroy(CurrentLevelObject.gameObject);
        }

        public void InitLevel(string levelName)
        {
            var level = _levels.FirstOrDefault(q => q.LevelName == levelName);
            if (level == null)
            {
                return;
            }
            CurrentLevel = level;
            var instantiatedLevel = Object.Instantiate(level.LevelObject, _levelsRoot);
            _playerView.transform.position = instantiatedLevel.PlayerSpawnPosition.position;
            
        }
    }
}