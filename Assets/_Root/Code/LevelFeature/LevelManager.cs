using System.Linq;
using _Root.Code.LevelManager;
using _Root.Code.UI;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code.GlobalManagers
{
    public class LevelManager : MonoBehaviour
    {
        private PlayerView _playerView;
        private static LevelManager _levelManager;
        [SerializeField] private Transform _levelsRoot;
        [SerializeField] private LevelSO[] _levels;
        [SerializeField] private UIManager _uiManager;
        public LevelSO CurrentLevel {get; private set;}
        public Level CurrentLevelObject {get; private set;}

        public static LevelManager Instance
        {
            get
            {
                return _levelManager;
            }
        }

        [Inject]
        public void Initialize(SignalBus signalBus)
        {
            signalBus.Subscribe<PlayerCreatedSignal>(OnPlayerCreated);
            _levelManager ??= this;
        }

        private void OnPlayerCreated(PlayerCreatedSignal obj)
        {
            _playerView = obj.PlayerView;
        }

        public void DestroyLevel()
        {
            Object.Destroy(CurrentLevelObject.gameObject);
            _uiManager.DestroyDialogView();
        }
        
        

        public void InitLevel(string levelName)
        {
            _playerView.gameObject.SetActive(false);
            var level = _levels.FirstOrDefault(q => q.LevelName == levelName);
            if (level == null)
            {
                return;
            }
            _uiManager.DestroyMainMenu();
            _uiManager.CreateDialogView();
            CurrentLevel = level;
            CurrentLevelObject = Object.Instantiate(level.LevelObject, _levelsRoot);
            _playerView.transform.position = CurrentLevelObject.PlayerSpawnPosition.position;
            _playerView.gameObject.SetActive(true);
        }

        public void InitializeMainMenu()
        {
            _uiManager.CreateMainMenu();
        }
    }
}