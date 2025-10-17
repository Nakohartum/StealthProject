using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace _Root.CleanCode.AStar.Infrastructure
{
    public class LevelBoundsProvider : MonoBehaviour
    {
        [Header("Scan Roots (optional)")]
        [SerializeField] private Transform scanRoot;

        [Header("Direct Sources (optional)")]
        [SerializeField] private List<Renderer> renderers = new();
        [SerializeField] private List<Collider2D> colliders2D = new();

        [Header("Fallback")]
        [SerializeField] private bool fallbackToAllSceneRenderers = true;
        
        #if UNITY_EDITOR
        [Header("Debug")]
        [SerializeField] private bool drawBoundsGizmo = true;
        #endif

        public bool TryGetWorldBounds(out Bounds b)
        {
            var hasAny = false;
            b = new Bounds(Vector3.zero, Vector3.zero);

            // 1) Explicit lists
            foreach (var r in renderers) if (r) AddBounds(ref b, ref hasAny, r.bounds);
            foreach (var c in colliders2D) if (c) AddBounds(ref b, ref hasAny, c.bounds);

            // 2) Scan root
            if (scanRoot)
            {
                foreach (var r in scanRoot.GetComponentsInChildren<Renderer>(true))
                    if (r) AddBounds(ref b, ref hasAny, r.bounds);
                foreach (var c in scanRoot.GetComponentsInChildren<Collider2D>(true))
                    if (c) AddBounds(ref b, ref hasAny, c.bounds);
            }

            // 3) Fallback
            if (!hasAny && fallbackToAllSceneRenderers)
            {
                foreach (var r in FindObjectsOfType<Renderer>())
                    if (r && r.enabled && r.gameObject.activeInHierarchy)
                        AddBounds(ref b, ref hasAny, r.bounds);
            }

            return hasAny;
        }

        private static void AddBounds(ref Bounds total, ref bool hasAny, Bounds nb)
        {
            if (!hasAny) { total = nb; hasAny = true; }
            else total.Encapsulate(nb);
        }
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (!drawBoundsGizmo) return;

            if (!TryGetWorldBounds(out var b)) return;

            // Draw bounds as a wireframe rectangle (2D view uses X/Y plane).
            if (drawBoundsGizmo)
            {
                Gizmos.color = Color.blue;
                var c = b.center;
                var s = b.size;
                // Clamp Z to small thickness so it’s visible in 3D scene
                if (s.z < 0.01f) s.z = 0.01f;
                Gizmos.DrawWireCube(c, s);
            }
        }
#endif
    }
}
