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
        //Shortcuts to the underlying Vector2 position
        public float x { get { return m_position.x; }}
        public float y { get {return m_position.y;} }

        public Vector2 Position { get { return m_position; } }
        private Vector2 m_position;
        public Coin(string name, float x, float y)
        {
            Name = name;
            m_position = new Vector2(x, y);
        }
    }

}
