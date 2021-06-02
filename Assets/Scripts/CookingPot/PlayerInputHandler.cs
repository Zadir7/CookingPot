using CookingPot.Update;
using UnityEngine;

namespace CookingPot
{
    public class PlayerInputHandler : IUpdatable
    {
        private readonly PlayerController _playerController;

        private readonly KeyCode _useKey = KeyCode.E;

        internal PlayerInputHandler(PlayerController playerController)
        {
            _playerController = playerController;
            UpdaterStatic.AddToUpdatables(this);
        }

        public void Update()
        {
            HandlePlayerInput();
        }
        
        private void HandlePlayerInput()
        {
            HandleUseKey();
        }

        private void HandleUseKey()
        {
            if (!Input.GetKeyDown(_useKey)) return;
            
            if (_playerController.HasItemInHand)
            {
                _playerController.UseItem();
            }
            else
            {
                if (_playerController.IsAbleToPickUp)
                {
                    _playerController.PickUpItem();
                }
            }
        }
    }
}
