using System;
using System.Collections.Generic;
using _Root.CleanCode.Shared.Ports;

namespace _Root.CleanCode.AStar.Domain
{
    public sealed class AStarSolver
    {
        private readonly Grid2D _grid;
        private readonly bool _allowDiagonal;
        private readonly float _heuristicWeight;
        private readonly int _searchNodeLimit;

        public AStarSolver(Grid2D grid, bool allowDiagonal, float heuristicWeight, int searchNodeLimit)
        {
            _grid = grid;
            _allowDiagonal = allowDiagonal;
            _heuristicWeight = heuristicWeight <= 0f ? 1f : heuristicWeight;
            _searchNodeLimit = Math.Max(1000, searchNodeLimit);
        }

        public bool TryFindPath(Vec2 from, Vec2 to, out IReadOnlyList<Vec2> path)
        {
            path = Array.Empty<Vec2>();

            if (!_grid.WorldToCell(from, out var start) || !_grid.WorldToCell(to, out var goal))
                return false;

            if (!_grid.IsWalkable(start.x, start.y) || !_grid.IsWalkable(goal.x, goal.y))
                return false;

            int startId = _grid.Id(start.x, start.y);
            int goalId  = _grid.Id(goal.x, goal.y);

            var open = new MinHeap(256);
            var cameFrom = new Dictionary<int, int>(256);
            var gScore = new Dictionary<int, float>(256) { [startId] = 0f };

            open.Push(new NodeCost(startId, Heuristic(start.x, start.y, goal.x, goal.y)));

            int expanded = 0;
            while (open.Count > 0)
            {
                var current = open.Pop();
                if (current.Id == goalId)
                {
                    path = Reconstruct(cameFrom, current.Id, startId);
                    return true;
                }

                expanded++;
                if (expanded > _searchNodeLimit)
                    return false;

                _grid.Unpack(current.Id, out var cx, out var cy);

                foreach (var n in _grid.Neighbors(cx, cy, _allowDiagonal))
                {
                    if (!_grid.IsWalkable(n.x, n.y)) continue;
                    int nid = _grid.Id(n.x, n.y);

                    float tentative = gScore[current.Id] + StepCost(cx, cy, n.x, n.y);
                    if (!gScore.TryGetValue(nid, out var old) || tentative < old)
                    {
                        cameFrom[nid] = current.Id;
                        gScore[nid] = tentative;
                        float f = tentative + Heuristic(n.x, n.y, goal.x, goal.y);
                        open.Push(new NodeCost(nid, f));
                    }
                }
            }

            return false;
        }

        private float Heuristic(int ax, int ay, int bx, int by)
        {
            int dx = Math.Abs(ax - bx);
            int dy = Math.Abs(ay - by);
            if (_allowDiagonal)
            {
                int dMin = Math.Min(dx, dy);
                int dMax = Math.Max(dx, dy);
                return _heuristicWeight * (1.41421356f * dMin + (dMax - dMin));
            }
            return _heuristicWeight * (dx + dy);
        }

        private static float StepCost(int ax, int ay, int bx, int by)
        {
            int dx = Math.Abs(ax - bx);
            int dy = Math.Abs(ay - by);
            return (dx + dy) == 2 ? 1.41421356f : 1f;
        }

        private IReadOnlyList<Vec2> Reconstruct(Dictionary<int, int> cameFrom, int currentId, int startId)
        {
            var list = new List<Vec2>(32);
            int cur = currentId;
            while (true)
            {
                list.Add(_grid.CellCenter(cur));
                if (cur == startId) break;
                cur = cameFrom[cur];
            }
            list.Reverse();
            return list;
        }

        private readonly struct NodeCost : IComparable<NodeCost>
        {
            public readonly int Id;
            public readonly float F;
            public NodeCost(int id, float f) { Id = id; F = f; }
            public int CompareTo(NodeCost other) => F.CompareTo(other.F);
        }

        private sealed class MinHeap
        {
            private NodeCost[] _arr;
            private int _count;

            public int Count => _count;

            public MinHeap(int capacity) { _arr = new NodeCost[Math.Max(4, capacity)]; }

            public void Push(NodeCost v)
            {
                if (_count >= _arr.Length) Array.Resize(ref _arr, _arr.Length * 2);
                _arr[_count] = v;
                SiftUp(_count++);
            }

            public NodeCost Pop()
            {
                var root = _arr[0];
                _count--;
                if (_count > 0)
                {
                    _arr[0] = _arr[_count];
                    SiftDown(0);
                }
                return root;
            }

            private void SiftUp(int i)
            {
                while (i > 0)
                {
                    int p = (i - 1) >> 1;
                    if (_arr[p].F <= _arr[i].F) break;
                    Swap(i, p);
                    i = p;
                }
            }

            private void SiftDown(int i)
            {
                while (true)
                {
                    int l = (i << 1) + 1;
                    if (l >= _count) break;
                    int r = l + 1;
                    int m = (r < _count && _arr[r].F < _arr[l].F) ? r : l;
                    if (_arr[i].F <= _arr[m].F) break;
                    Swap(i, m);
                    i = m;
                }
            }

            private void Swap(int a, int b)
            {
                (_arr[a], _arr[b]) = (_arr[b], _arr[a]);
            }
        }
    }
}