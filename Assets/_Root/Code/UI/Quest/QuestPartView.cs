using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestPartView : MonoBehaviour
{
     [SerializeField] private Toggle _questPartCompleted;
     [SerializeField] private TMP_Text _questPartName;
     [SerializeField] private TMP_Text _questPartProgress;

     public void SetQuestPartCompleted(bool value)
     {
          _questPartCompleted.isOn = value;
     }

     public void SetQuestPartName(string value)
     {
          _questPartName.text = value;
     }

     public void SetQuestPartProgress(string value)
     {
          _questPartProgress.text = value;
     }
}
