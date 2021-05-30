using CookingPot.Update;

namespace CookingPot
{
    internal sealed class PlayerController : IUpdatable
    {
        private Player player;
        private RightHand rightHand;
        
        private bool isAbleToPickUp;
        private Item itemToPickup;

        internal bool IsAbleToPickUp => isAbleToPickUp;

        internal PlayerController(Player player, RightHand rightHand)
        {
            this.player = player;
            this.rightHand = rightHand;
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        internal void SetItemToPickup(bool isAbleToPickUp, Item item)
        {
            this.isAbleToPickUp = isAbleToPickUp;
            itemToPickup = item;
        }

        internal void ResetPickupItem()
        {
            isAbleToPickUp = false;
            itemToPickup = null;
        }
    }
}