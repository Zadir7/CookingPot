using CookingPot.Items;
using CookingPot.Update;
using UnityEngine;

namespace CookingPot
{
    internal sealed class PlayerController : IUpdatable, IHealth
    {
        private Player _player;
        private RightHand _rightHand;
        
        private bool _isAbleToPickUp;
        private Item _itemToPickup;
        private Item _itemInHand;

        private readonly float _healthDrainAmount = 1;
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }

        internal bool IsAbleToPickUp => _isAbleToPickUp;

        internal PlayerController(Player player, RightHand rightHand)
        {
            this._player = player;
            this._rightHand = rightHand;
        }

        public void Update()
        {
            DrainHealth(_healthDrainAmount * Time.deltaTime);
        }

        private void DrainHealth(float amount)
        {
            CurrentHealth -= amount;
            Debug.Log(CurrentHealth);
            if (CurrentHealth <= 0)
            {
                GameObject.Destroy(_player);
            }
        }
        public void RestoreHealth(float amount)
        {
            CurrentHealth += amount;
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }

        #region ItemInteraction
        
        internal void SetItemToPickup(bool isAbleToPickUp, Item item)
        {
            this._isAbleToPickUp = isAbleToPickUp;
            _itemToPickup = item;
        }

        internal void ResetPickupItem()
        {
            _isAbleToPickUp = false;
            _itemToPickup = null;
        }

        internal void PickUpItem()
        {
            if (_isAbleToPickUp)
            {
                var itemTransform = _itemToPickup.transform;
                var rightHandTransform = _rightHand.transform;
                
                itemTransform.position = rightHandTransform.position;
                itemTransform.parent = rightHandTransform;
                _itemInHand = _itemToPickup;
                ResetPickupItem();
            }
        }

        internal void UseItem()
        {
            if (_itemInHand == null)
            {
                return;
            }
            if (_itemInHand is Edible)
            {
                (_itemInHand as Edible)?.Use(this);
            }
        }
        
        #endregion
    }
}