using _Root.Code.QuestFeature.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code.UI
{
    public class QuestView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [field: SerializeField] public RectTransform QuestPartsContainer {get; private set;}

        public void SetTitle(string value)
        {
            _title.SetText(value);
        }
        
    }
}

