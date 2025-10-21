using _Root.CleanCode.AStar.Domain;
using _Root.CleanCode.Shared.Ports;
using _Root.CleanCode.Shared.Ports.AStar;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.AStar.Infrastructure
{
    /// <summary>
    /// Zenject installer that binds INavigationPort to A*.
    /// Can auto-build grid based on level bounds or use manual values from AStarConfig.
    /// </summary>
    public sealed class NavigationInstaller : MonoInstaller
    {
        [Header("Mode")]
        [Tooltip("If true, grid size/origin are derived from scene bounds.")]
        public bool AutoFromLevel = true;

        [Tooltip("Provider used to compute level bounds when AutoFromLevel=true.")]
        public LevelBoundsProvider BoundsProvider;

        [Header("Grid")]
        [Tooltip("World size of one cell (Unity units).")]
        public float CellSize = 0.5f;

        [Tooltip("Padding (in world units) added around computed bounds.")]
        public float Padding = 0.0f;

        [Header("Manual Fallback (used if AutoFromLevel is false or bounds not found)")]
        public AStarConfig ManualConfig;

        [Header("Pathfinding")]
        public bool AllowDiagonal = true;
        [Range(0.1f, 5f)] public float HeuristicWeight = 1.0f;
        [Min(1000)] public int SearchNodeLimit = 20000;

        public override void InstallBindings()
        {
            Vec2 origin;
            int width, height;

            if (AutoFromLevel && TryBuildFromLevel(out origin, out width, out height))
            {
                // ok
            }
            else
            {
                if (ManualConfig == null)
                {
                    Debug.LogWarning("NavigationInstaller: Using fallback grid (64x64). Assign ManualConfig or enable AutoFromLevel.");
                    origin = new Vec2(0, 0);
                    width = 64; height = 64;
                }
                else
                {
                    origin = new Vec2(ManualConfig.Origin.x, ManualConfig.Origin.y);
                    width = Mathf.Max(1, ManualConfig.GridSize.x);
                    height = Mathf.Max(1, ManualConfig.GridSize.y);
                    CellSize = Mathf.Max(0.0001f, ManualConfig.CellSize);
                    AllowDiagonal = ManualConfig.AllowDiagonal;
                    HeuristicWeight = ManualConfig.HeuristicWeight;
                    SearchNodeLimit = Mathf.Max(1000, ManualConfig.SearchNodeLimit);
                }
            }

            var grid = new Grid2D(width, height, origin, Mathf.Max(0.0001f, CellSize));
            Container.Bind<Grid2D>().FromInstance(grid).AsSingle();

            Container.Bind<INavigationPort>()
                .To<AStarNavigationAdapter>()
                .AsSingle()
                .WithArguments(AllowDiagonal, HeuristicWeight, SearchNodeLimit);
        }

        private bool TryBuildFromLevel(out Vec2 origin, out int width, out int height)
        {
            origin = new Vec2(0, 0); width = height = 0;
            if (BoundsProvider == null || !BoundsProvider.TryGetWorldBounds(out var b))
                return false;

            if (Padding > 0f) b.Expand(Padding * 2f);

            var min = b.min; var size = b.size;
            origin = new Vec2(min.x, min.y);

            float cs = Mathf.Max(0.0001f, CellSize);
            width = Mathf.Max(1, Mathf.CeilToInt(size.x / cs));
            height = Mathf.Max(1, Mathf.CeilToInt(size.y / cs));
            return true;
        }
    }
}