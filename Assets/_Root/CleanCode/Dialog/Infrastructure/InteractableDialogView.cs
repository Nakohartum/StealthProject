using System.Text;
using _Root.CleanCode.Dialog.Application;
using _Root.CleanCode.Dialog.Application.Ports;
using _Root.CleanCode.Shared.Ports;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Root.CleanCode.Dialog.Infrastructure
{
    public class InteractableDialogView : MonoBehaviour, IDialogView
    {
        [SerializeField] private TMP_Text _actorLabel;
        [SerializeField] private TMP_Text _messageLabel;
        [SerializeField] private Image _image;
        private IAddressablesPort _addressablesPort;
        public bool IsOpen => gameObject.activeInHierarchy;

        [Inject]
        public void Initialize(IAddressablesPort addressablesPort)
        {
            _addressablesPort = addressablesPort;
        }

        private async UniTask LoadPortrait(string imageUrl)
        {
            var sprite = await _addressablesPort.LoadAsync<Sprite>(imageUrl);
            _image.sprite = sprite;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _actorLabel.text = "";
            _messageLabel.text = "";
            _image.sprite = null;
            _addressablesPort.UnloadAsync(_image.sprite).Forget();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void ShowLine(string line)
        {
            _messageLabel.text = line;
        }

        public void ShowAuthor(string author)
        {
            _actorLabel.text = author;
        }

        public async UniTask ShowImage(string image)
        {
            if (!string.IsNullOrEmpty(image))
            {
                await LoadPortrait(image);
            }
        }
    }
}