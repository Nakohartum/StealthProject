using System;
using _Root.CleanCode.InteractableFeature.Application;
using _Root.CleanCode.InteractableFeature.Application.Ports;
using _Root.CleanCode.InteractableFeature.Domain;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.InteractableFeature.Infrastructure
{
    [RequireComponent(typeof(InteractableObject))]
    public class InteractableObjectInstaller : MonoInstaller
    {
        [SerializeField] private InteractableObjectConfig _interactableObjectConfig;
        [SerializeField] private InteractableObject _interactableObject;
        public override void InstallBindings()
        {
            Container.Bind<InteractableModel>().FromMethod(_interactableObjectConfig.ToModel).AsTransient().NonLazy();
            Container.Bind<InteractableObjectState>().AsTransient().NonLazy();
            if (_interactableObjectConfig.StartSoundKey != String.Empty)
            {
                Container.Bind<IInteractionStrategy>().To<PlaySoundStrategy>().AsTransient().NonLazy();
            }

            if (_interactableObjectConfig.DialogKey != String.Empty)
            {
                Container.Bind<IInteractionStrategy>().To<PlayDialogStrategy>().AsTransient().NonLazy();
            }
            
            Container.Bind<InteractionUseCase>().AsTransient().NonLazy();
            
            Container.Bind<ToggleInteractionStyleUseCase>().AsTransient().NonLazy();
            
            Container.BindInterfacesAndSelfTo<InteractableObject>().FromInstance(_interactableObject).AsTransient().NonLazy();
        }
    }
}