using TMPro;
using UnityEngine;
using Zenject;

namespace _Root.Code.QuestFeature.View
{
    public class QuestView : MonoBehaviour
    {
        [field: SerializeField]
        public RectTransform QuestPartsContainer { get; private set; }
        [SerializeField] private TMP_Text _titleText;

        public class QuestViewFactory : PlaceholderFactory<QuestView>{}

        public void SetTitle(string questModelName)
        {
            _titleText.text = questModelName;
        }
    }
}