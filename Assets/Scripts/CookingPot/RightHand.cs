using System;
using CookingPot.Items;
using UnityEngine;

namespace CookingPot
{
    public class RightHand : MonoBehaviour
    {
        internal PlayerController PlayerController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Item>(out var item))
            {
                PlayerController.SetItemToPickup(true, item);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (PlayerController.IsAbleToPickUp)
            {
                PlayerController.ResetPickupItem();
            }
        }
    }
}