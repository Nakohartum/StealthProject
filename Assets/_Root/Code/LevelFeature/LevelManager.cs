using System;
using System.Collections.Generic;
using System.Linq;
using _Root.Code.AStar.Pathfinder;
using _Root.Code.CutsceneFeature.Manager;
using _Root.Code.LevelFeature;
using _Root.Code.LevelManager;
using GameOne.Player;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace _Root.Code.GlobalManagers
{
    public class LevelManager 
    {
        private Transform _levelsRoot;
        private LevelSO[] _levels;
        public Level CurrentLevelObject {get; private set;}
        private CutsceneManager _cutsceneManager;
        private DiContainer _container;
        private IFactory<Transform, PlayerController> _playerFactory;
        private PathfinderPresenter _pathfinderPresenter;
        public event Action OnLevelLoaded;

        [Inject]
        public LevelManager(Transform levelsRoot, LevelSO[] levels, CutsceneManager cutsceneManager, DiContainer container, IFactory<Transform, PlayerController> playerFactory, PathfinderPresenter pathfinderPresenter)
        {
            _levelsRoot = levelsRoot;
            _levels = levels;
            _cutsceneManager = cutsceneManager;
            _container = container;
            _playerFactory = playerFactory;
            _pathfinderPresenter = pathfinderPresenter;
        }

        private void DestroyLevel()
        {
            Object.Destroy(CurrentLevelObject.gameObject);
        }

        public void InitLevel(string levelName)
        {
            if (CurrentLevelObject != null)
            {
                DestroyLevel();
            }
            var level = _levels.FirstOrDefault(q => q.LevelName == levelName);
            if (level == null)
            {
                return;
            }
            CurrentLevelObject = _container.InstantiatePrefabForComponent<Level>(level.LevelObject, _levelsRoot);
            _playerFactory.Create(CurrentLevelObject.PlayerSpawnPosition);
            if (CurrentLevelObject.StartingCutsceneName != "")
            {
                _cutsceneManager.StartCutscene(CurrentLevelObject.StartingCutsceneName);
            }

            var levelBounds = CurrentLevelObject.GetLevelBounds();
            var size = levelBounds.size;
            var center = levelBounds.center;
            _pathfinderPresenter.GenerateGrid(size, center);
            _pathfinderPresenter.UpdateWalkable();
            OnLevelLoaded?.Invoke();
        }
    }
}