using System;
using _Root.Code.Input;
using _Root.Code.Weapon.WeaponSoundsPlayer;
using GameOne.Weapon;
using Zenject;

namespace _Root.Code.Weapon.WeaponPresenter
{
    public class WeaponPresenter : IDisposable, IAttack
    {
        private GameOne.Weapon.WeaponView.WeaponView _weaponView;
        private IAttack _weaponModel;
        private InputController _inputController;
        private WeaponsSoundsPlayer _weaponsSoundsPlayer;

        [Inject]
        public WeaponPresenter(GameOne.Weapon.WeaponView.WeaponView strikeWeaponView, IAttack strikeWeaponModel,
            InputController inputController, WeaponsSoundsPlayer weaponsSoundsPlayer)
        {
            _weaponView = strikeWeaponView;
            _weaponModel = strikeWeaponModel;
            _inputController = inputController;
            _weaponsSoundsPlayer = weaponsSoundsPlayer;
        }

        public void Dispose()
        {
            _weaponView.OnSoundPlay -= _weaponsSoundsPlayer.PlayRandomWeaponSounds;
        }

        public void Attack()
        {
            _weaponModel.Attack();
            _weaponView.PlaySound();
        }
    }
}