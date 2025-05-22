using _Root.Code.AStar.Grid;
using UnityEngine;

namespace _Root.Code.AStar.Pathfinder
{
    public class PathfinderModel
    {
        public Grid.Grid Grid { get; private set; }
        private Vector3 _origin;
        private float _cellSize;
        public int Width;
        public int Height;
        private LayerMask _layerMask;

        public PathfinderModel(Vector3 origin, float cellSize, int width, int height, LayerMask layerMask)
        {
            var centeredOrigin = origin - new Vector3(width * cellSize, height * cellSize, 0) * 0.5f;
            _origin = centeredOrigin;
            _cellSize = cellSize;
            Width = width;
            Height = height;
            _layerMask = layerMask;
            
        }

        public void GenerateGrid()
        {
            Grid = new Grid.Grid(Width, Height,  _cellSize, _origin, _layerMask);
        }
        public void GenerateGrid(Vector3 size, Vector3 center)
        {
            Width = Mathf.CeilToInt(size.x / _cellSize);
            Height = Mathf.CeilToInt(size.y / _cellSize);
            Grid = new Grid.Grid(Width, Height,  _cellSize, center, _layerMask);
        }

        public void UpdateGridWalkability()
        {
            for (int x = 0; x < Width; x++)
            {   
                for (int y = 0; y < Height; y++)
                {
                    Vector3 worldPos = _origin + new Vector3(x * _cellSize, y * _cellSize, 0);
                    var hit = Physics2D.OverlapCircle(worldPos, _cellSize * 0.4f, _layerMask);
                    bool walkable = hit == null || hit.isTrigger;
                    Node node = Grid.GetNode(x, y);
                    node.IsWalkable = walkable;
                    
                }
            }
        }
        
        public Vector3Int WorldToGrid(Vector3 worldPos)
        {
            var local = worldPos - _origin;
            var x = Mathf.FloorToInt(local.x / _cellSize);
            var y = Mathf.FloorToInt(local.y / _cellSize);
            return new Vector3Int(
                x,
                y,
                0);
        }

        public Vector3 GridToWorld(Node node)
        {
            return _origin + new Vector3(node.X * _cellSize, node.Y * _cellSize);
        }
    }
}