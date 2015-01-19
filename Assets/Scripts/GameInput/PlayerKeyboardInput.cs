using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Scripts.GameInput
{
    class PlayerKeyboardInput: PlayerInput
    {
        public PlayerKeyboardInput(IPlayer player) : base(player)
        {
        }

        public override void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                Player.Jump();
            }
            if (Input.GetKey("left"))
            {
                Player.Run(PlayerDirection.Left);
            }
            if (Input.GetKey("right"))
            {
                Player.Run(PlayerDirection.Right);
            }
        }
    }
}
