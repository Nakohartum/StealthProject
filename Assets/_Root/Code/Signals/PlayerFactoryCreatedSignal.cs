using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Code.Signals
{
    public class PlayerFactoryCreatedSignal
    {
        public IFactory<Transform, PlayerView> PlayerFactory;
    }
}