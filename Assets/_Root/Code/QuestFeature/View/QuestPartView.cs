using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Root.Code.QuestFeature.View
{
    public class QuestPartView : MonoBehaviour
    {
        [SerializeField] private Toggle _partCompleted;
        [SerializeField] private TMP_Text _questPartName;
        [SerializeField] private TMP_Text _questPartProgress;
        public void SetQuestPartCompleted(bool questPartIsDone)
        {
            _partCompleted.isOn = questPartIsDone;
        }

        public void SetQuestPartName(string questPartName)
        {
            _questPartName.text = questPartName;
        }

        public void SetQuestPartProgress(string progression)
        {
            _questPartProgress.text = progression;
        }
        public class QuestPartViewFactory : PlaceholderFactory<QuestPartView>{}
    }
}