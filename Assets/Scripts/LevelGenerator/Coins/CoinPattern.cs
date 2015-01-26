using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.LevelGenerator.Coins
{
    class CoinPattern
    {
        private readonly ICollection<Vector2> m_coins;
        private readonly ICollection<Vector2> m_spacedCoins;
        public Rect Bounds { get; protected set; }
        public float CoinSpace { get; protected set; }
        public ICollection<Vector2> CoinsInPattern { get { return m_coins; }}
        public ICollection<Vector2> SpacedCoins { get { return m_spacedCoins; } } 
        public CoinPattern(ICollection<Vector2> coins, Rect bounds, float coinSpace)
        {
            m_coins = coins;
            Bounds = bounds;
            CoinSpace = coinSpace;
            m_spacedCoins = m_coins.Select(coinPos => new Vector2(coinPos.x*CoinSpace, coinPos.y*CoinSpace)).ToArray();
        } 

    }
}
