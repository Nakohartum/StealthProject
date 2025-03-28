using System;
using System.Collections.Generic;
using _Root.Code.DialogFeature.SO;
using _Root.Code.InteractiveObjects.InteractionStrategy;
using UnityEngine;
using Zenject;

namespace _Root.Code.InteractiveObjects.Installers
{
    public class InteractiveObjectInstaller : MonoInstaller
    {
        [Header("Outline")]
        [SerializeField] private OutlineFx.OutlineFx _outlineFx;
        [Header("Sounds")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _onClip;
        [SerializeField] private AudioClip _loopClip;
        [SerializeField] private AudioClip _offClip;
        [Header("Dialog")]
        [SerializeField] private Dialog _dialog;

        public override void InstallBindings()
        {
            
        }

        public override void Start()
        {
            base.Start();
            var interactiveObject = GetComponent<InteractableObject>();
            var list = new List<IInteractionStrategy>();
            if (_audioSource != null)
            {
                var playSoundsStrategy = new PlaySoundsStrategy(_audioSource, _onClip, _offClip, _loopClip);
                list.Add(playSoundsStrategy);
            }

            if (_dialog != null)
            {
                var dialogStrategy = Container.Instantiate<ShowDialogStrategy>(new object[]{_dialog});
                list.Add(dialogStrategy);
            }
            
            interactiveObject.Initialize(
                _outlineFx,
                list.ToArray()
            );
        }
    }
}