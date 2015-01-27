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
        public string Name { get; protected set; }
        public float x { get; protected set; }
        public float y { get; protected set; }

        public Coin(string name, float x, float y)
        {
            Name = name;
            this.x = x;
            this.y = y;
        }
    }

}
