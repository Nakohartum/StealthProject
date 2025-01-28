using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code.UI
{
    public class DialogView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _image;

        public void SetImage(Sprite sprite)
        {
            _image.sprite = sprite;
        }
        
        public void SetText(string value)
        {
            _text.SetText(value);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}