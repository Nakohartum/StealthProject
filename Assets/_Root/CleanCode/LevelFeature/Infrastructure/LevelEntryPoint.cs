using _Root.CleanCode.LevelFeature.Domain;
using _Root.CleanCode.QuestFeature.Infrastructure;
using UnityEditor.SearchService;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.LevelFeature.Infrastructure
{
    public sealed class LevelEntryPoint : MonoBehaviour
    {
        [SerializeField] private LevelConfig _config;

        private ILevelControl _level;

        [Inject]
        public void Construct(ILevelControl level)
        {
            _level = level;
        }

        private void Start()
        {
            if (_config == null)
            {
                Debug.LogWarning("[LevelEntryPoint] Missing LevelConfig");
                _level.StartLevel(new LevelStartParams("Unknown", System.Array.Empty<string>(), null));
                return;
            }

            _level.StartLevel(new LevelStartParams(
                _config.LevelId,
                _config.AutoStartEvents,
                _config.InitialCutsceneId
            ));

            
        }
    }
}