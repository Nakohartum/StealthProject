using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using _Root.Code.Input;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Root.Code.UI
{
    public class DialogController
    {
        private DialogView _dialogView;
        private InputController _inputController;
        private CancellationTokenSource _textCancellationTokenSource;
        private CancellationTokenSource _blinkTextCancellationTokenSource;

        [Inject]
        private DialogController(DialogView dialogView, InputController inputController)
        {
            _dialogView = dialogView;
            _inputController = inputController;
            _instance = this;
            SetActive(false);
        }

        private static DialogController _instance;

        public static DialogController Instance
        {
            get
            {
                return _instance;
            }
        }

        private void ResetCancellationToken(ref CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
        }
        
        public async Task  SetText(List<EditorHelpers.KeyValuePair<string, EditorHelpers.KeyValuePair<string, Sprite>>> texts)
        {
            _dialogView.BlinkText(0f);
            ResetCancellationToken(ref _textCancellationTokenSource);
            ResetCancellationToken(ref _blinkTextCancellationTokenSource);
            
            if (texts.Count > 0)
            {
                _inputController.EnableAnyKey();
                _inputController.DisablePlayerMove();
                _inputController.DisableInteractionKey();
                if (_dialogView.gameObject.activeSelf != true)
                {
                    _dialogView.SetActive(true);
                }
                for (int i = 0; i < texts.Count; i++)
                {
                    SetTitle(texts[i].Value.Key);
                    SetImage(texts[i].Value.Value);
                    await SetText(texts[i].Key);
                    BlinkNextText(_blinkTextCancellationTokenSource.Token);
                    await WaitForAnyKey();
                }
                SetActive(false);
            
                _inputController.DisableAnyKey();
                _inputController.EnablePlayerMove();
                _inputController.EnableInteractionKey();
            }
        }

        private async Task BlinkNextText(CancellationToken token)
        {
            _inputController.DisableAnyKey();
            _inputController.EnableAnyKey();
            while (!token.IsCancellationRequested)
            {
                if (_inputController.AnyKeyPressed())
                {
                    _blinkTextCancellationTokenSource.Cancel();
                }

                for (float i = 0; i <= 1; i+=0.05f)
                {
                    _dialogView.BlinkText(i);
                    var taskDelay = Task.Delay(50, _blinkTextCancellationTokenSource.Token);
                    await taskDelay;
                }
                for (float i = 1; i >= 0; i-=0.05f)
                {
                    _dialogView.BlinkText(i);
                    var taskDelay = Task.Delay(50, _blinkTextCancellationTokenSource.Token);
                    await taskDelay;
                }
            }
            _dialogView.BlinkText(0f);
        }

        private async Task WaitForAnyKey()
        {
            _inputController.DisableAnyKey();
            await Task.Yield();
            _inputController.EnableAnyKey();
            while (!_inputController.AnyKeyPressed())
            {
                await Task.Yield();
            }
            _inputController.DisableAnyKey();
            await Task.Yield();
            _inputController.EnableAnyKey();
            _textCancellationTokenSource.Cancel();
        }

        private void SetTitle(string title)
        {
            _dialogView.SetTitle(title);
        }

        private async Task SetText(string text)
        {
            var shownText = "";
            foreach (var character in text)
            {
                if (_inputController.AnyKeyPressed())
                {
                    _textCancellationTokenSource.Cancel();
                }

                if (_textCancellationTokenSource.IsCancellationRequested)
                {
                    break;
                }
                shownText += character;
                _dialogView.SetText(shownText);
                var waitTask = Task.Delay(150, _textCancellationTokenSource.Token);
                await waitTask;
            }
            _dialogView.SetText(text);
        }

        private void SetImage(Sprite sprite)
        {
            _dialogView.SetImage(sprite);
        }

        private void SetActive(bool active)
        {
            _dialogView.SetActive(active);
        }
        
    }
}