using CookingPot.Update;
using UnityEngine;

namespace CookingPot
{
    internal class CameraController : IFixedUpdatable
    {
        private readonly Vector3 _offset;
        private readonly Transform _cameraTransform;
        private readonly Transform _playerTransform;

        public CameraController(Transform playerTransform, Transform cameraTransform)
        {
            _playerTransform = playerTransform;
            _cameraTransform = cameraTransform;
            _offset = _playerTransform.transform.position - _cameraTransform.transform.position;
            UpdaterStatic.AddToUpdatables(this);
        }

        public void FixedUpdate()
        {
            _cameraTransform.transform.position = _playerTransform.transform.position - _offset;
        }
    }
}