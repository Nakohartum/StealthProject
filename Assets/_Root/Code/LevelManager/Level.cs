using System;
using System.Collections.Generic;
using _Root.Code.QuestFeature.Controller;
using UnityEngine;
using Zenject;

namespace _Root.Code.LevelManager
{
    public class Level : MonoBehaviour
    {
        [field: SerializeField] public List<EditorHelpers.KeyValuePair<string, AudioClip>> LevelMusic { get; private set; }
        [field: SerializeField] public Transform PlayerSpawnPosition { get; private set; }
        public List<IDisposable> Disposables { get; private set; } = new();

        public void AddDisposable(IDisposable disposable)
        {
            Disposables.Add(disposable);
        }

        public void RemoveDisposable(IDisposable disposable)
        {
            Disposables.Remove(disposable);
        }

        private void OnDestroy()
        {
            foreach (var disposable in Disposables)
            {
                disposable.Dispose();
            }
        }
    }
}