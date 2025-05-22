using System;
using System.Collections.Generic;
using _Root.Code.CutsceneFeature.Manager;
using _Root.Code.CutsceneFeature.Model;
using _Root.Code.GlobalManagers;
using _Root.Code.QuestFeature.Controller;
using UnityEngine;
using Zenject;

namespace _Root.Code.LevelManager
{
    public class Level : MonoBehaviour
    {
        [field: SerializeField] public AudioClip StartingLevelMusic { get; private set; }
        [field: SerializeField] public string StartingCutsceneName { get; private set; }
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

        public Bounds GetLevelBounds()
        {
            var renderers = GetComponentsInChildren<Renderer>(true);
            if (renderers.Length == 0)
                return new Bounds(transform.position, Vector3.zero);
            Bounds bounds = renderers[0].bounds;
            foreach (var renderer in renderers)
            {
                bounds.Encapsulate(renderer.bounds);
            }

            return bounds;
        }
    }
}