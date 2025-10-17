using System;
using System.Collections.Generic;
using _Root.CleanCode.Shared.Ports;

namespace _Root.CleanCode.AStar.Domain
{
    public sealed class Grid2D
    {
        private readonly bool[,] _blocked;
        private readonly float _cellSize;
        private readonly Vec2 _origin;

        public int Width { get; }
        public int Height { get; }

        public Grid2D(int width, int height, Vec2 origin, float cellSize)
        {
            Width = Math.Max(1, width);
            Height = Math.Max(1, height);
            _origin = origin;
            _cellSize = Math.Max(0.0001f, cellSize);
            _blocked = new bool[Width, Height];
        }

        public int Id(int x, int y) => y * Width + x;

        public void Unpack(int id, out int x, out int y)
        {
            x = id % Width;
            y = id / Width;
        }

        public bool IsInside(int x, int y) => (uint)x < (uint)Width && (uint)y < (uint)Height;
        public bool IsWalkable(int x, int y) => IsInside(x, y) && !_blocked[x, y];

        public bool WorldToCell(Vec2 w, out (int x, int y) cell)
        {
            var fx = (w.X - _origin.X) / _cellSize;
            var fy = (w.Y - _origin.Y) / _cellSize;
            int x = (int)Math.Floor(fx);
            int y = (int)Math.Floor(fy);
            cell = (x, y);
            return IsInside(x, y);
        }

        public Vec2 CellCenter(int id)
        {
            Unpack(id, out var x, out var y);
            var cx = _origin.X + (x + 0.5f) * _cellSize;
            var cy = _origin.Y + (y + 0.5f) * _cellSize;
            return new Vec2(cx, cy);
        }

        public IEnumerable<(int x, int y)> Neighbors(int x, int y, bool diag)
        {
            // 4-way
            if (IsInside(x - 1, y)) yield return (x - 1, y);
            if (IsInside(x + 1, y)) yield return (x + 1, y);
            if (IsInside(x, y - 1)) yield return (x, y - 1);
            if (IsInside(x, y + 1)) yield return (x, y + 1);

            // Diagonals
            if (diag)
            {
                if (IsInside(x - 1, y - 1)) yield return (x - 1, y - 1);
                if (IsInside(x + 1, y - 1)) yield return (x + 1, y - 1);
                if (IsInside(x - 1, y + 1)) yield return (x - 1, y + 1);
                if (IsInside(x + 1, y + 1)) yield return (x + 1, y + 1);
            }
        }

        public void SetObstacleAabb(Rect2 aabb, bool enabled)
        {
            int x0 = (int)Math.Floor((aabb.XMin - _origin.X) / _cellSize);
            int y0 = (int)Math.Floor((aabb.YMin - _origin.Y) / _cellSize);
            int x1 = (int)Math.Floor((aabb.XMax - _origin.X) / _cellSize);
            int y1 = (int)Math.Floor((aabb.YMax - _origin.Y) / _cellSize);

            if (x1 < 0 || y1 < 0 || x0 >= Width || y0 >= Height) return;

            x0 = Math.Max(0, x0); y0 = Math.Max(0, y0);
            x1 = Math.Min(Width - 1, x1); y1 = Math.Min(Height - 1, y1);

            for (int y = y0; y <= y1; y++)
                for (int x = x0; x <= x1; x++)
                    _blocked[x, y] = enabled;
        }
    }
}