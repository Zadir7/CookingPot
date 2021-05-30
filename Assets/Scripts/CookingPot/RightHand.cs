using System;
using UnityEngine;

namespace CookingPot
{
    public class RightHand : MonoBehaviour
    {
        internal PlayerController _playerController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Item>(out var item))
            {
                _playerController.SetItemToPickup(true, item);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_playerController.IsAbleToPickUp)
            {
                _playerController.ResetPickupItem();
            }
        }
    }
}