using System.Collections.Generic;
using CookingPot.Items;
using CookingPot.Update;
using UnityEngine;
using static CookingPot.Update.UpdaterStatic;

namespace CookingPot
{
    internal sealed class GameController : MonoBehaviour
    {
        [SerializeField] 
        [Tooltip("Объект игрока")]
        private Player player;
        
        [SerializeField] 
        private RightHand rightHand;
        
        [SerializeField] 
        [Tooltip("Начальная скорость игрока")]
        private float playerSpeed = 3.0f;
        
        [SerializeField] 
        private Transform camera;
        
        [SerializeField] 
        private GameObject endGameLabel;
        
        [SerializeField] 
        private GameObject currentHpLabel;

        private PlayerController _playerController;
        private PlayerInputHandler _playerInputHandler;
        private PlayerMoveHandler _playerMoveHandler;
        private CameraController _cameraController;
        private CurrentHpLabel _currentHpLabel;
        
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

            _currentHpLabel = new CurrentHpLabel(currentHpLabel, _playerController);

            _playerController.OnPlayerDeath += EndGame;
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

        private void EndGame()
        {
            RemoveFromUpdatables(_playerController);
            RemoveFromUpdatables(_playerInputHandler);
            RemoveFromUpdatables(_playerMoveHandler);
            RemoveFromUpdatables(_cameraController);
            Destroy(player.gameObject);
            player = null;
            _currentHpLabel.Disable();
            var endGameView = new EndGameView(endGameLabel);
        }
    }
}