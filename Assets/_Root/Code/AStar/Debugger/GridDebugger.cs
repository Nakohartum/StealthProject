using _Root.Code.AStar.Grid;
using _Root.Code.AStar.Pathfinder;
using UnityEngine;

namespace _Root.Code.AStar.Debugger
{
    public class GridDebugger : MonoBehaviour
    {
            [SerializeField] private Color walkableColor = Color.green;
            [SerializeField] private Color blockedColor = Color.red;
            [SerializeField] private float cellMargin = 0.05f;

            private PathfinderModel _model;

            public void Initialize(PathfinderModel model)
            {
                _model = model;
            }

            private void OnDrawGizmos()
            {
                if (_model == null || _model.Grid == null)
                    return;

                var grid = _model.Grid;
                float size = _model.CellSize - cellMargin;

                for (int x = 0; x < _model.Width; x++)
                for (int y = 0; y < _model.Height; y++)
                {
                    Node node = grid.GetNode(x, y);
                    Vector3 pos = _model.GridToWorld(node) + Vector3.one * (_model.CellSize * 0.5f);
                    Gizmos.color = node.IsWalkable ? walkableColor : blockedColor;
                    Gizmos.DrawCube(pos, Vector3.one * size);
                }
            }
        }
    }
