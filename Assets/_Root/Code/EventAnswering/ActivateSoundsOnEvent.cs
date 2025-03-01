using System;
using _Root.Code.Miscellanious;
using UnityEngine;
using EventType = _Root.Code.Miscellanious.EventType;

namespace _Root.Code.EventAnswering
{
    public class ActivateSoundsOnEvent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _activateSound;
        [SerializeField] private EventType _eventType;
        [SerializeField] private bool _looping;

        private void Start()
        {
            EventBus.AddSubscriber(_eventType, ActivateSound);
        }

        private void ActivateSound()
        {
            Debug.Log("Played");
            if (_activateSound != null)
            {
                _audioSource.loop = _looping;
                _audioSource.clip = _activateSound;
                _audioSource.Play();
            }
        }

        private void OnDestroy()
        {
            EventBus.RemoveSubscriber(_eventType, ActivateSound);
        }
    }
}