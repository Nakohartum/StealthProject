using _Root.Code.DialogFeature.SO;
using _Root.Code.QuestFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.QuestFeature
{
    public class QuestViewFactory : IFactory<QuestView>
    {
        private  Transform _root;
        
        private QuestView _view;

        public QuestViewFactory(QuestView view)
        {
            _view = view;
        }

        public void SetRoot(Transform root)
        {
            _root = root;
        }

        public QuestView Create()
        {
            return Object.Instantiate(_view, _root);
        }
    }
}