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
        [SerializeField] private Color _interactableColor;
        [SerializeField] private SpriteRenderer _outlineObject;
        [SerializeField] private Animator _animator;
        [SerializeField] private DialogSO _dialogSo;
        [SerializeField] private List<EditorHelpers.KeyValuePair<bool, AudioClip>> _audioClips;
        [SerializeField] private AudioSource _interactSound;
        private bool _hasTextToShow;
        private bool _hasAudio;
        private bool _hasAnimationToShow;
        private bool _isObjectStartedInteraction;
        private Coroutine _soundCoroutine;

        private void Awake()
        {
            _outlineObject.color = _interactableColor;
            _outlineObject.gameObject.SetActive(false);
            _hasTextToShow = _dialogSo != null && _dialogSo.TextToShow.Count > 0;
            _hasAudio = _interactSound != null && _audioClips.Count > 0;
            _hasAnimationToShow = _animator != null;
        }

        public bool InteractionToggled { get; private set; }

        public void SetInteractionStyleOn()
        {
            InteractionToggled = true;
            _outlineObject.gameObject.SetActive(true);
        }

        public void SetInteractionStyleOff()
        {
            InteractionToggled = false;
            _outlineObject.gameObject.SetActive(false);
        }

        public void Interact()
        {
            if (_hasAnimationToShow)
            {
                //TODO: play animation
                Debug.Log("Animation played");
            }

            if (_hasTextToShow)
            {
                DialogController.Instance.SetText(_dialogSo.TextToShow);
            }

            if (_hasAudio)
            {
                ToggleState();
                if (_isObjectStartedInteraction)
                {
                    PlaySounds(_audioClips[0]);
                    if (_audioClips[1].Value != null)
                    {
                        PlaySounds(_audioClips[1]);
                    }
                    
                }
                else
                {
                    PlaySounds(_audioClips[2]);
                }
            }

            OnInteractionDone();
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
                StartLoopingSoundAfterDelay(audioClip.Value, _audioClips[0].Value.length);
            }
            else
            {
                _interactSound.Stop();
                _interactSound.PlayOneShot(audioClip.Value);
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

        public event Action OnInteractionDone = () => { };
    }
}