using System;
using System.Collections.Generic;
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
        
        public async Task  SetText(List<EditorHelpers.KeyValuePair<string, Sprite>> texts)
        {
            if (texts.Count > 0)
            {
                _inputController.EnableAnyKey();
                _inputController.DisablePlayerMove();
                if (_dialogView.gameObject.activeSelf != true)
                {
                    _dialogView.SetActive(true);
                }
                for (int i = 0; i < texts.Count; i++)
                {
                    SetText(texts[i].Key);
                    SetImage(texts[i].Value);
                    await WaitForAnyKey();
                }
                SetActive(false);
            
                _inputController.DisableAnyKey();
                _inputController.EnablePlayerMove();
            }
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
        }

        private void SetText(string text)
        {
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