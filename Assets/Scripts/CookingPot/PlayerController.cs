using System;
using CookingPot.Items;
using CookingPot.Update;
using UnityEngine;
using Object = UnityEngine.Object;

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
        
        internal bool IsAbleToPickUp => _isAbleToPickUp;
        internal bool HasItemInHand => _itemInHand != null;
        
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }

        public event Action OnPlayerDeath = () => { };
        public event Action OnHealthDrain = () => { };

        internal PlayerController(Player player, RightHand rightHand)
        {
            this._player = player;
            this._rightHand = rightHand;
            MaxHealth = 100.0f;
            CurrentHealth = 100.0f;
            UpdaterStatic.AddToUpdatables(this);
        }

        public void Update()
        {
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnPlayerDeath.Invoke();
            }
            else
            {
                DrainHealth(_healthDrainAmount * Time.deltaTime);
            }
        }

        private void DrainHealth(float amount)
        {
            CurrentHealth -= amount;
            OnHealthDrain();
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
                var itemRigidbody = _itemToPickup.gameObject.GetComponent<Rigidbody>();
                
                itemTransform.position = rightHandTransform.position;
                itemTransform.parent = rightHandTransform;
                itemRigidbody.useGravity = false;
                _itemInHand = _itemToPickup;
                ResetPickupItem();
            }
        }

        internal void UseItem()
        {
            if (_itemInHand is null)
            {
                return;
            }
            if (_itemInHand is Edible edible)
            {
                edible.Use(this);
            }
        }
        
        #endregion
    }
}