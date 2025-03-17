using UnityEngine;

namespace _Root.Code.UI
{
    public class QuestViewCreator
    {
        private QuestView _questViewPrefab;
        private readonly QuestPartView _questPartViewPrefab;
        private QuestView _currentQuestView;

        public QuestViewCreator(QuestView questViewPrefab, QuestPartView questPartViewPrefab)
        {
            _questViewPrefab = questViewPrefab;
            _questPartViewPrefab = questPartViewPrefab;
        }

        public QuestPartView CreateQuestPartView(RectTransform root)
        {
            return Object.Instantiate(_questPartViewPrefab, root);
        }
        
        public QuestView CreateQuestView(Transform root)
        {
            if (_currentQuestView != null)
            {
                return _currentQuestView;
            }
            
            _currentQuestView = Object.Instantiate(_questViewPrefab, root);
            return _currentQuestView;
        }

        public void DestroyQuestView()
        {
            if (_currentQuestView == null) return;
            Object.Destroy(_currentQuestView.gameObject);
            _currentQuestView = null;
        }
    }
}