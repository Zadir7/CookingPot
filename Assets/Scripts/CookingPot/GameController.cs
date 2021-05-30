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

        private PlayerController playerController;
        
        private void Start()
        {
            Updatables = new List<IUpdatable>();
            FixedUpdatables = new List<IFixedUpdatable>();
            LateUpdatables = new List<ILateUpdatable>();

            playerController = new PlayerController(player, rightHand);
            rightHand._playerController = playerController;
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