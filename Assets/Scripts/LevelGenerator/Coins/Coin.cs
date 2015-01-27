using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.LevelGenerator.Coins
{
    class Coin
    {
        public CoinType Type { get; protected set; }
        public float x { get; protected set; }
        public float y { get; protected set; }

        public Coin(CoinType type, float x, float y)
        {
            Type = type;
            this.x = x;
            this.y = y;
        }
    }

    public enum CoinType
    {
        Regular
    }
}
