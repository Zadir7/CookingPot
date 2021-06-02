using System.Collections.Generic;
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

        private PlayerController _playerController;
        private PlayerInputHandler _playerInputHandler;
        private PlayerMoveHandler _playerMoveHandler;
        
        private void Start()
        {
            Updatables = new List<IUpdatable>();
            FixedUpdatables = new List<IFixedUpdatable>();
            LateUpdatables = new List<ILateUpdatable>();

            _playerController = new PlayerController(player, rightHand);
            rightHand.PlayerController = _playerController;
            _playerInputHandler = new PlayerInputHandler(_playerController);
            _playerMoveHandler = new PlayerMoveHandler(player.transform, playerSpeed);
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
    }
}