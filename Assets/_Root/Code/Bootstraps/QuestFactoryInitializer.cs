using _Root.Code.QuestFeature;
using UnityEngine;
using Zenject;

namespace _Root.Code.Bootstraps
{
    public class QuestFactoryInitializer : IInitializable
    {
        private QuestViewFactory _viewFactory;
        private Transform _root;

        public QuestFactoryInitializer(QuestViewFactory viewFactory, Transform root)
        {
            _viewFactory = viewFactory;
            _root = root;
        }

        public void Initialize()
        {
            _viewFactory.SetRoot(_root);
        }
    }
}