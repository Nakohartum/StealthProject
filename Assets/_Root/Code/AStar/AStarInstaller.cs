using _Root.Code.AStar.Pathfinder;
using UnityEngine;
using Zenject;

namespace _Root.Code.AStar
{
    public class AStarInstaller : MonoInstaller
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private float _cellSize;
        [SerializeField] private LayerMask _layerMask;
        public override void InstallBindings()
        {
            var model = new PathfinderModel(gameObject.transform.position, _cellSize, _width, _height, _layerMask);
            Container.Bind<PathfinderPresenter>().AsSingle().WithArguments(model).NonLazy();
        }
    }
}