using _Root.Code.AStar.Grid;
using UnityEngine;

namespace _Root.Code.AStar.Pathfinder
{
    public class PathfinderModel
    {
        public Grid.Grid Grid { get; private set; }
        private Vector3 _origin;
        private float _cellSize;
        private int _width;
        private int _height;

        public PathfinderModel(Vector3 origin, float cellSize, int width, int height)
        {
            _origin = origin;
            _cellSize = cellSize;
            _width = width;
            _height = height;
        }

        public void GenerateGrid()
        {
            Grid = new Grid.Grid(_width, _height,  _cellSize, _origin);
        }

        public void UpdateGridWalkability()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    Vector3 worldPos = _origin + new Vector3(x * _cellSize, y * _cellSize, 0);
                    bool walkable = !Physics2D.OverlapCircle(worldPos, _cellSize * 0.4f);
                    Node node = Grid.GetNode(x, y);
                    node.IsWalkable = walkable;
                }
            }
        }
    }
}