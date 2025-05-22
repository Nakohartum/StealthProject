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

        public Grid(int width, int height, float cellSize, Vector3 origin, LayerMask layerMask)
        {
            _width = width;
            _height = height;
            _cellSize = cellSize;
            _grid = new Node[_width, _height];
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _grid[x, y] = CreateNode(x,y, origin, layerMask);
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
            var dirs = new (int dx, int dy)[] {
                (-1,  0), // left
                ( 1,  0), // right
                ( 0, -1), // down
                ( 0,  1), // up
                (-1, -1), (1, -1), // diagonals
                (-1,  1), (1,  1)
            };
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
        
        private Node CreateNode(int x, int y, Vector3 origin, LayerMask layerMask)
        {
            Vector3 worldPosition = origin + new Vector3(x * _cellSize, y * _cellSize, 0);
            var hit = Physics2D.OverlapCircle(worldPosition, _cellSize * 0.4f, layerMask);
            bool walkable = hit == null || hit.isTrigger;
            
            return new Node(x, y, walkable);
        }

        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && y >= 0 && x < _width && y < _height;
        }
    }
}