using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LevelGenerator.Coins
{
    class CoinPattern
    {
        private readonly ICollection<Vector2> m_coins;
        public Rect Bounds { get; protected set; }
        public ICollection<Vector2> CoinsInPattern { get { return m_coins; }}  
        public CoinPattern(ICollection<Vector2> coins, Rect bounds)
        {
            m_coins = coins;
            Bounds = bounds;
        } 

    }
}
