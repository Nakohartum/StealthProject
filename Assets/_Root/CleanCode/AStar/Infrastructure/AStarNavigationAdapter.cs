using _Root.CleanCode.AStar.Domain;
using _Root.CleanCode.Shared.Ports;
using _Root.CleanCode.Shared.Ports.AStar;

namespace _Root.CleanCode.AStar.Infrastructure
{
    public class AStarNavigationAdapter : INavigationPort
    {
        private readonly Grid2D _grid;
        private readonly AStarSolver _solver;

        public AStarNavigationAdapter(Grid2D grid, bool allowDiagonal, float heuristicWeight, int searchNodeLimit)
        {
            _grid = grid;
            _solver = new AStarSolver(grid, allowDiagonal, heuristicWeight, searchNodeLimit);
        }

        public bool TryFindPath(Vec2 from, Vec2 to, out System.Collections.Generic.IReadOnlyList<Vec2> path)
            => _solver.TryFindPath(from, to, out path);

        public void SetDynamicObstacle(Rect2 aabb, bool enabled)
            => _grid.SetObstacleAabb(aabb, enabled);
    }
    
}