using System.Collections.Generic;
using UnityEngine;

namespace _Root.Code.AStar.Grid
{
    public class Grid
    {
        private Node[,] _grid;
        private int _width;
        private int _height;
        private float _cellSize;

        public Grid(int width, int height, float cellSize, Vector3 origin)
        {
            _width = width;
            _height = height;
            _cellSize = cellSize;
            _grid = new Node[_width, _height];
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _grid[x, y] = CreateNode(x,y, origin);
                }
            }
        }

        public Node GetNode(int x, int y)
        {
            return _grid[x, y];
        }
        
        public Node[,] GetRawNodes() => _grid;

        public IEnumerable<Node> GetNeighbors(Node node)
        {
            var dirs = new[] { (0, 1), (1, 0), (0, -1), (-1, 0), (1, 1), (-1, 1), (1, -1), (-1, -1), };
            foreach (var (dx, dy) in dirs)
            {
                int nx = node.X + dx;
                int ny = node.Y + dy;
                if (nx >= 0 && ny >= 0 && nx < _width && ny < _height)
                {
                    yield return _grid[nx, ny];
                }
            }
        }
        
        private Node CreateNode(int x, int y, Vector3 origin)
        {
            Vector3 worldPosition = origin + new Vector3(x * _cellSize, y * _cellSize, 0);
            bool walkable = !Physics2D.OverlapCircle(worldPosition, _cellSize * 0.4f);
            return new Node(x, y, walkable);
        }
    }
}