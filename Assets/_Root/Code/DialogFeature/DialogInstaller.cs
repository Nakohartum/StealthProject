using _Root.Code.DialogFeature.Factory;
using _Root.Code.DialogFeature.Presenter;
using _Root.Code.DialogFeature.SO;
using _Root.Code.DialogFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.DialogFeature
{
    public class DialogInstaller : MonoInstaller
    {
        [SerializeField] private DialogView _dialogViewPrefab;
        public override void InstallBindings()
        {   
            Container.Bind<IFactory<Dialog, DialogPresenter>>().To<DialogFactory>().AsSingle().WithArguments(_dialogViewPrefab);
        }
    }
}