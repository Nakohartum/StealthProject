using System;
using System.Collections.Generic;
using _Root.CleanCode.Cutscene.Application;
using UnityEngine;

namespace _Root.CleanCode.Cutscene.Infrastructure
{
    [CreateAssetMenu(fileName = "CutsceneCatalogConfig", menuName = "Create/Cutscene/Cutscene Catalog")]
    public sealed class CutsceneCatalogConfig : ScriptableObject, ICutsceneCatalogPort, ICutsceneCatalogRuntime
    {
        [Serializable]
        public struct Entry
        {
            [Tooltip("Logical id used by missions to start this cutscene.")]
            public string Id;

            [Tooltip("Addressables key for a prefab that has a PlayableDirector.")]
            public string AddressableKey;

            [Tooltip("Whether this cutscene can be skipped by player.")]
            public bool Skippable;
        }

        [SerializeField] private List<Entry> _entries = new List<Entry>();

        private readonly Dictionary<string, Entry> _map = new Dictionary<string, Entry>(StringComparer.Ordinal);

        private void OnEnable()
        {
            _map.Clear();
            foreach (var e in _entries)
            {
                if (!string.IsNullOrEmpty(e.Id))
                    _map[e.Id] = e;
            }
        }

        public bool TryGetSkippable(string cutsceneId, out bool skippable)
        {
            if (_map.TryGetValue(cutsceneId, out var e))
            {
                skippable = e.Skippable;
                return true;
            }
            skippable = false;
            return false;
        }

        public bool TryResolveKey(string cutsceneId, out string addressableKey)
        {
            if (_map.TryGetValue(cutsceneId, out var e))
            {
                addressableKey = e.AddressableKey;
                return true;
            }
            addressableKey = null;
            return false;
        }
    }
}