using _Root.CleanCode.QuestFeature.Infrastructure;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.LevelFeature.Infrastructure
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class LevelTrigger : MonoBehaviour
    {
        [SerializeField] private string _triggerId = "Unnamed";

        private ILevelControl _level;

        [Inject]
        public void Construct(ILevelControl level)
        {
            _level = level;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _level.OnTrigger(_triggerId);
        }
    }
}