using System;
using System.Collections;
using System.Threading;
using _Root.Code.DialogFeature.Presenter;
using Cysharp.Threading.Tasks;
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
        
        private DialogPresenter _dialogPresenter;
        

        public void Initialize(DialogPresenter dialogPresenter)
        {
            _dialogPresenter = dialogPresenter;
        }

        public void SetDialogMeta(string characterName,Sprite characterImage)
        {
            _characterImage.sprite = characterImage;
            _characterName.text = characterName;
        }

        public async UniTask ShowDialogAsync(string dialogText, CancellationToken token)
        {
            _nextLabel.alpha = 0.0f;
            var shownText = "";
            foreach (var symbol in dialogText)
            {
                token.ThrowIfCancellationRequested();
                shownText += symbol;
                ShowLine(shownText);
                await UniTask.Delay(TimeSpan.FromSeconds(_showCooldown), cancellationToken: token);
            }
        }

        public void ShowLine(string line)
        {
            _dialogText.text = line;
        }

        public async UniTask ShowNextLabelAsync(CancellationToken token)
        {
            var deltaTime = Time.deltaTime;

            while (true)
            {
                for (float i = 0; i < 1f; i+=deltaTime)
                {
                    _nextLabel.alpha = i;
                }
                _nextLabel.alpha = 1.0f;
                for (float i = 1.0f; i > 0; i-=deltaTime)
                {
                    _nextLabel.alpha = i;
                }
                
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }
        }

        public void CloseDialog()
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
        
    }
}