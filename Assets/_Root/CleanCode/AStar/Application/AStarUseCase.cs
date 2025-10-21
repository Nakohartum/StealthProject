using System.Collections.Generic;
using _Root.CleanCode.Shared.Ports;
using _Root.CleanCode.Shared.Ports.AStar;

namespace _Root.CleanCode.AStar.Application
{
    public class AStarUseCase
    {
        private readonly INavigationPort _nav;

        public AStarUseCase(INavigationPort nav) { _nav = nav; }

        /// <summary> Finds a path between two world points. </summary>
        public bool TryFindPath(Vec2 from, Vec2 to, out IReadOnlyList<Vec2> path)
            => _nav.TryFindPath(from, to, out path);

        /// <summary> Enables/disables a dynamic obstacle AABB. </summary>
        public void SetDynamicObstacle(Rect2 aabb, bool enabled)
            => _nav.SetDynamicObstacle(aabb, enabled);
    }
}