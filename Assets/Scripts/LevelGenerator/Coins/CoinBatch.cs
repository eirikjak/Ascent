using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.LevelGenerator.Coins
{
    class CoinBatch
    {
        public Rect Bounds { get; set; }
        public ICollection<Coin> Coins { get; set; } 
    }
}
