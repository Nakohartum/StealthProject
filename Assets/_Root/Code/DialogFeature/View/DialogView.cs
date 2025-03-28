using System;
using System.Collections;
using _Root.Code.DialogFeature.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code.DialogFeature.View
{
    public class DialogView : MonoBehaviour
    {
        [SerializeField] private Image _characterImage;
        [SerializeField] private TMP_Text _characterName;
        [SerializeField] private TMP_Text _dialogText;
        [SerializeField] private TMP_Text _nextLabel;
        private readonly float _showCooldown = 0.05f;
        
        private Coroutine _showDialogCoroutine;
        private Coroutine _showNextLabelCoroutine;
        private WaitForSeconds _waitForSeconds;
        private DialogPresenter _dialogPresenter;
        

        private void Awake()
        {
            _waitForSeconds = new WaitForSeconds(_showCooldown);
        }

        public void Initialize(DialogPresenter dialogPresenter)
        {
            _dialogPresenter = dialogPresenter;
        }

        public void ShowDialog(string characterName, string dialogText, Sprite characterImage, Action onLabelWritten)
        {
            _characterImage.sprite = characterImage;
            _characterName.text = characterName;
            _showDialogCoroutine = StartCoroutine(ShowDialog(dialogText, onLabelWritten));
        }

        private IEnumerator ShowDialog(string dialogText, Action onLabelWritten)
        {
            _nextLabel.alpha = 0.0f;
            var shownText = "";
            foreach (var symbol in dialogText)
            {
                shownText += symbol;
                ShowLine(shownText);
                yield return _waitForSeconds;
            }

            onLabelWritten();
        }

        public void StopShowingDialog()
        {
            if (_showDialogCoroutine != null)
            {
                StopCoroutine(_showDialogCoroutine);
            }
        }

        public void ShowLine(string line)
        {
            _dialogText.text = line;
        }

        public void StartBlinkLabel()
        {
            _showNextLabelCoroutine = StartCoroutine(ShowNextLabel());
        }

        private IEnumerator ShowNextLabel()
        {
            var deltaTime = Time.deltaTime;

            while (true)
            {
                for (float i = 0; i < 1f; i+=deltaTime)
                {
                    _nextLabel.alpha = i;
                    yield return null;
                }
                _nextLabel.alpha = 1.0f;
                for (float i = 1.0f; i > 0; i-=deltaTime)
                {
                    _nextLabel.alpha = i;
                    yield return null;
                }
                _nextLabel.alpha = 0.0f;
            }
        }

        public void CloseDialog()
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }

        public void StopBlinking()
        {
            if (_showNextLabelCoroutine != null)
            {
                StopCoroutine(_showNextLabelCoroutine);
            }
            _nextLabel.alpha = 0f;
        }
    }
}