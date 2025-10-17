using System.Collections.Generic;

namespace _Root.CleanCode.Shared.Ports.AStar
{
    public interface INavigationPort
    {
        /// <summary>Try to find a path from A to B.</summary>
        bool TryFindPath(Vec2 from, Vec2 to, out IReadOnlyList<Vec2> path);

        /// <summary>Enable or disable a dynamic obstacle by AABB.</summary>
        void SetDynamicObstacle(Rect2 aabb, bool enabled);
    }
}