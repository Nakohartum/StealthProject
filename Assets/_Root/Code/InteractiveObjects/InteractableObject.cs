using System;
using System.Collections;
using System.Collections.Generic;
using _Root.Code.EditorHelpers;
using _Root.Code.UI;
using UnityEngine;
using UnityEngine.Audio;

namespace _Root.Code.InteractiveObjects
{
    public class InteractableObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private OutlineFx.OutlineFx _outlineObject;
        [SerializeField] private Animator _animator;
        [SerializeField] private DialogSO _dialogSo;
        [SerializeField] private List<EditorHelpers.KeyValuePair<bool, AudioClip>> _audioClips;
        [SerializeField] private AudioSource _interactSound;
        private bool _hasTextToShow;
        private bool _hasAudio;
        private bool _hasAnimationToShow;
        private bool _isObjectStartedInteraction;
        private Coroutine _soundCoroutine;
        public bool InteractionToggled { get; private set; }
        

        private void Start()
        {
            _outlineObject.enabled = false;
            _hasTextToShow = _dialogSo != null && _dialogSo.TextToShow.Count > 0;
            _hasAudio = _interactSound != null && _audioClips.Count > 0;
            _hasAnimationToShow = _animator != null;
        }

        

        public void SetInteractionStyleOn()
        {
            if (this.enabled)
            {
                InteractionToggled = true;
                _outlineObject.enabled = true;
            }
        }

        public void SetInteractionStyleOff()
        {
            InteractionToggled = false;
            _outlineObject.enabled = false;
        }

        public void Interact()
        {
            ToggleState();
            _interactSound.Stop();
            if (_hasAudio)
            {
                PlayAudio();
            }

            if (_hasAnimationToShow)
            {
                PlayAnimation();
            }

            if (_hasTextToShow)
            {
                DialogController.Instance.SetText(_dialogSo.TextToShow);
            }
        }

        private void PlayAnimation()
        {
            
        }

        private void PlayAudio()
        {
            if (_audioClips.Count == 3)
            {
                if (_isObjectStartedInteraction)
                {
                    if (_audioClips[0].Value != null)
                    {
                        PlaySounds(_audioClips[0]);
                    }
                    PlaySounds(_audioClips[1]);
                }
                else
                {
                    
                    PlaySounds(_audioClips[2]);
                }
            }
            else if (_audioClips.Count == 1)
            {
                PlaySounds(_audioClips[0]);
            }
        }

        private void ToggleState()
        {
            _isObjectStartedInteraction = !_isObjectStartedInteraction;
        }

        private void PlaySounds(EditorHelpers.KeyValuePair<bool, AudioClip> audioClip)
        {
            if (audioClip.Key)
            {
                if (_soundCoroutine != null)
                {
                    StopCoroutine(_soundCoroutine);
                    
                }
                StartLoopingSoundAfterDelay(audioClip.Value, _audioClips[0].Value == null? 0 : _audioClips[0].Value.length);
            }
            else
            {
                _interactSound.Stop();
                if (audioClip.Value != null)
                {
                    _interactSound.PlayOneShot(audioClip.Value);
                }
            }
        }

        private void StartLoopingSoundAfterDelay(AudioClip audioClipValue, float valueLength)
        {
            _soundCoroutine = StartCoroutine(StartAudioAfterDelay(audioClipValue, valueLength));
        }

        private IEnumerator StartAudioAfterDelay(AudioClip audioClipValue, float valueLength)
        {
            yield return new WaitForSeconds(valueLength);
            _interactSound.loop = true;
            _interactSound.clip = audioClipValue;
            _interactSound.Play();
        }
    }
}