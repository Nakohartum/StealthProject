using System.Collections.Generic;
using System.Linq;
using _Root.Code.AStar.Grid;
using UnityEngine;

namespace _Root.Code.AStar.Pathfinder
{
    public class AStarPathfinder
    {
        public List<Node> FindPath(Node start, Node goal, Grid.Grid grid)
        {
            var openSet = new List<Node> { start };
            var closedSet = new HashSet<Node>();

            foreach (var node in grid.GetRawNodes())
            {
                node.GCost = int.MaxValue;
                node.HCost = 0;
                node.Parent = null;
            }

            start.GCost = 0;
            start.HCost = GetHeuristic(start, goal);

            while (openSet.Count > 0)
            {
                Node current = GetLowestCost(openSet);
                if (current == goal)
                {
                    return RetracePath(start, goal);
                }

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (var neighbor in grid.GetNeighbors(current))
                {
                    if (!grid.IsInBounds(neighbor.X, neighbor.Y) || !neighbor.IsWalkable || closedSet.Contains(neighbor))
                        continue;

                    int dx = neighbor.X - current.X;
                    int dy = neighbor.Y - current.Y;

                    // Проверка на блоки при диагональном движении
                    if (Mathf.Abs(dx) == 1 && Mathf.Abs(dy) == 1)
                    {
                        if (!grid.IsInBounds(current.X + dx, current.Y) ||
                            !grid.IsInBounds(current.X, current.Y + dy))
                            continue;

                        Node nodeA = grid.GetNode(current.X + dx, current.Y);
                        Node nodeB = grid.GetNode(current.X, current.Y + dy);
                        if (!nodeA.IsWalkable || !nodeB.IsWalkable)
                            continue;
                    }

                    int tentativeG = current.GCost + GetDistance(current, neighbor);
                    if (tentativeG < neighbor.GCost || !openSet.Contains(neighbor))
                    {
                        neighbor.GCost = tentativeG;
                        neighbor.HCost = GetHeuristic(neighbor, goal);
                        neighbor.Parent = current;

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }

            return null;
        }

        private int GetHeuristic(Node a, Node b)
        {
            int dx = Mathf.Abs(a.X - b.X);
            int dy = Mathf.Abs(a.Y - b.Y);
            int D = 10;
            int D2 = 14;
            return D * (dx + dy) + (D2 - 2 * D) * Mathf.Min(dx, dy);
        }

        private int GetDistance(Node a, Node b)
        {
            int dx = Mathf.Abs(a.X - b.X);
            int dy = Mathf.Abs(a.Y - b.Y);
            return (dx + dy) == 2 ? 14 : 10;
        }

        private List<Node> RetracePath(Node start, Node goal)
        {
            var path = new List<Node>();
            Node current = goal;
            while (current != start)
            {
                path.Add(current);
                current = current.Parent;
            }
            path.Reverse();
            return path;
        }

        private Node GetLowestCost(List<Node> list)
        {
            Node best = list[0];
            foreach (var node in list)
            {
                if (node.FCost < best.FCost || (node.FCost == best.FCost && node.HCost < best.HCost))
                {
                    best = node;
                }
            }
            return best;
        }
    }
}