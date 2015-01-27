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
        public float X { get; protected set; }
        public float Y { get; protected set; }

        public Coin(CoinType type, float x, float y)
        {
            Type = type;
            X = x;
            Y = y;
        }
    }

    public enum CoinType
    {
        Regular
    }
}
