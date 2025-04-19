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
            var openSet = new List<Node>(){start};
            var closedSet = new HashSet<Node>();
            foreach (var node in openSet)
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
                    if (!neighbor.IsWalkable || closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    int dx = neighbor.X - current.X;
                    int dy = neighbor.Y - current.Y;

                    if (Mathf.Abs(dx) == 1 && Mathf.Abs(dy) == 1)
                    {
                        Node nodeA = grid.GetNode(current.X + dx, current.Y);
                        Node nodeB = grid.GetNode(current.X, current.Y + dy);
                        if (!nodeA.IsWalkable || !nodeB.IsWalkable)
                        {
                            continue;
                        }
                    }
                    int tentativeG = current.GCost + GetHeuristic(current, neighbor);
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

        private int GetHeuristic(Node nodeA, Node nodeB)
        {
            int dx = Mathf.Abs(nodeA.X - nodeB.X);
            int dy = Mathf.Abs(nodeA.Y - nodeB.Y);
            
            return 10 * Mathf.Max(dx, dy) + 4 * Mathf.Min(dx, dy);
        }

        private List<Node> RetracePath(Node start, Node goal)
        {
            List<Node> path = new List<Node>();
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