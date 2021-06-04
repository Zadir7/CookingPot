using System.Collections.Generic;
using CookingPot.Items;
using CookingPot.Update;
using UnityEngine;
using static CookingPot.Update.UpdaterStatic;

namespace CookingPot
{
    internal sealed class GameController : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private RightHand rightHand;
        [SerializeField] private float playerSpeed = 3.0f;
        [SerializeField] private Transform camera;

        private PlayerController _playerController;
        private PlayerInputHandler _playerInputHandler;
        private PlayerMoveHandler _playerMoveHandler;
        private CameraController _cameraController;
        
        private void Start()
        {
            Updatables = new List<IUpdatable>();
            FixedUpdatables = new List<IFixedUpdatable>();
            LateUpdatables = new List<ILateUpdatable>();

            _playerController = new PlayerController(player, rightHand);
            rightHand.PlayerController = _playerController;
            _playerInputHandler = new PlayerInputHandler(_playerController);
            _playerMoveHandler = new PlayerMoveHandler(player.transform, playerSpeed);
            _cameraController = new CameraController(player.transform, camera);

            _playerController.OnItemUsed += LogIfItemIsUsed;
        }
        
        private void Update()
        {
            foreach (var updatable in Updatables)
            {
                updatable.Update();
            }
        }

        private void FixedUpdate()
        {
            foreach (var updatable in FixedUpdatables)
            {
                updatable.FixedUpdate();
            }
        }

        private void LateUpdate()
        {
            foreach (var updatable in LateUpdatables)
            {
                updatable.LateUpdate();
            }
        }
        
        //temporary method
        private void LogIfItemIsUsed(Item item)
        {
            Debug.Log(item);
        }
    }
}