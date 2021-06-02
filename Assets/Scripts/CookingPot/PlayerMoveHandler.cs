using CookingPot.Update;
using UnityEngine;

namespace CookingPot
{
    public class PlayerMoveHandler : IFixedUpdatable
    {
        private readonly Transform _playerTransform;
        private readonly float _playerSpeed;
        
        
        private enum AxisToHandle : byte
        {
            Horizontal = 0,
            Vertical = 1
        }
        
        public PlayerMoveHandler(Transform playerTransform, float playerSpeed)
        {
            _playerTransform = playerTransform;
            _playerSpeed = playerSpeed;
            UpdaterStatic.AddToUpdatables(this);
        }
        public void FixedUpdate()
        {
            MovePlayer();
        }
        
        private void MovePlayer()
        {
            var direction = new Vector3(
                Input.GetAxis(AxisToHandle.Horizontal.ToString()),
                0,
                Input.GetAxis(AxisToHandle.Vertical.ToString())
                ).normalized;
            var movementTarget = direction * (_playerSpeed * Time.fixedDeltaTime);
            _playerTransform.Translate(movementTarget);
            
        }
    }
}