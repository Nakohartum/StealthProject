using _Root.Code.LevelFeature;
using _Root.Code.Signals;
using Cinemachine;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code.Installers
{
    
    public class PlayerProjectContextInstaller : MonoInstaller
    {
        
        [SerializeField] private PlayerSO _playerSo;
         
        public override void InstallBindings()
        {
            
            Container.Bind<PlayerProjectContextFactory>().AsSingle().WithArguments(_playerSo);
            Container.BindInterfacesAndSelfTo<PlayerProjectContextBootstrapper>().AsSingle();
        }
    }
}