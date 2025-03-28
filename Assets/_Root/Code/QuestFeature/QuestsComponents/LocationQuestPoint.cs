using System;
using _Root.Code.Miscellanious;
using GameOne.Player;
using UnityEngine;

namespace _Root.Code.QuestFeature.View
{
    public class LocationQuestPoint : MonoBehaviour
    {
        [SerializeField] private string _locationId;
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.TryGetComponent(typeof(PlayerView), out var _))
            {
                EventBus.InvokeLocationAchieved(_locationId);
                Destroy(gameObject);
            }
        }
    }
}