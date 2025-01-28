using System;
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
        [SerializeField] private List<EditorHelpers.KeyValuePair<string, Sprite>> _textToShow;
        [SerializeField] private List<EditorHelpers.KeyValuePair<bool, AudioClip>> _audioClips;
        [SerializeField] private AudioSource _interactSound;
        private bool _hasTextToShow;
        private bool _hasAudio;
        private bool _hasAnimationToShow;
        private bool _isObjectStartedInteraction;

        private void Awake()
        {
            _outlineObject.color = _interactableColor;
            _outlineObject.gameObject.SetActive(false);
            _hasTextToShow = _textToShow.Count > 0;
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
                DialogController.Instance.SetText(_textToShow);
            }

            if (_hasAudio)
            {
                //TODO: play sound
                ToggleState();
                if (_isObjectStartedInteraction)
                {
                    Debug.Log("Starting sound played");
                    
                }
                else
                {
                    Debug.Log("Stopping sound played");
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
                _interactSound.Stop();
                _interactSound.loop = audioClip.Key;
                _interactSound.clip = audioClip.Value;
                _interactSound.Play();
            }
            else
            {
                _interactSound.PlayOneShot(audioClip.Value);
            }
        }

        public event Action OnInteractionDone = () => { };
    }
}