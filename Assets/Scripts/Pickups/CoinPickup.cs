using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Pickups
{
    public delegate void OnCoinPickedUp(object sender, EventArgs args);
    class CoinPickup: Pickup
    {
        public event OnCoinPickedUp PickedUp;


        protected override void OnPlayerCollision(PlayerMovement player)
        {
            player.BoostUp();
            OnPickedUp();
            Destroy(gameObject);
        }

        protected virtual void OnPickedUp()
        {
            var handler = PickedUp;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
