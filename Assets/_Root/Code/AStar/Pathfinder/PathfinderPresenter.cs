using System.Collections.Generic;
using _Root.Code.AStar.Grid;
using UnityEngine;
using Zenject;

namespace _Root.Code.AStar.Pathfinder
{
    public class PathfinderPresenter
    {
        public PathfinderModel Model { get; }
        private readonly AStarPathfinder _pathfinder = new();
        private List<Node> _lastPath;

        public PathfinderPresenter(PathfinderModel model)
        {
            Model = model;
        }

        public void UpdateWalkable() => Model.UpdateGridWalkability();

        public List<Node> FindPath(Vector3 start, Vector3 end)
        {
            var startPos = Model.WorldToGrid(start);
            var endPos = Model.WorldToGrid(end);
            var startNode = Model.Grid.GetNode(startPos.x, startPos.y);
            var endNode = Model.Grid.GetNode(endPos.x, endPos.y);
            _lastPath = _pathfinder.FindPath(startNode, endNode, Model.Grid);
            return _lastPath;
        }
        
        public void DrawPathGizmos()
        {
            if (_lastPath == null) return;

            Gizmos.color = Color.cyan;
            foreach (var node in _lastPath)
            {
                Vector3 center = Model.GridToWorld(node) + Vector3.one * (0.5f * 0.5f);
                Gizmos.DrawSphere(center, 0.5f * 0.2f);
            }
        }

        public void GenerateGrid(Vector3 size, Vector3 center)
        {
            Model.GenerateGrid(size, center);
        }
    }
}