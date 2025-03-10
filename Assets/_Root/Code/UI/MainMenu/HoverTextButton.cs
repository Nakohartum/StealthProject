using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Root.Code.UI.MainMenu
{
    public class HoverTextButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [field: SerializeField] public Button Button { get; private set; }
        [field: SerializeField] public TMP_Text Text { get; private set; }
        [SerializeField] private Color _hoverTextColor = Color.red;
        [SerializeField] private Color _defaultColor = Color.green;

        private void Start()
        {
            Text.color = _defaultColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Text.color = _hoverTextColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Text.color = _defaultColor;
        }
    }
}