using UnityEngine;

namespace _Root.CleanCode.AStar.Infrastructure
{
    [UnityEngine.CreateAssetMenu(fileName = nameof(AStarConfig), menuName = "Create/AStar", order = 0)]
    public class AStarConfig : ScriptableObject
    {
        [Header("Grid")]
        [Tooltip("Bottom-left world position of the grid (Unity units).")]
        public Vector2 Origin = Vector2.zero;

        [Tooltip("Grid size in cells (X=columns, Y=rows).")]
        public Vector2Int GridSize = new Vector2Int(128, 128);

        [Tooltip("World size of one cell (Unity units).")]
        public float CellSize = 0.5f;

        [Header("Pathfinding")]
        [Tooltip("Allow diagonal movement.")]
        public bool AllowDiagonal = true;

        [Tooltip("Heuristic scaling. 1.0 = standard.")]
        [Range(0.1f, 5f)]
        public float HeuristicWeight = 1.0f;

        [Tooltip("Max nodes to expand before aborting (failsafe).")]
        public int SearchNodeLimit = 20000;
    }
}