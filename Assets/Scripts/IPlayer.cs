using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    interface IPlayer
    {
        void Run(PlayerDirection direction);
        void Jump();
    }
}
