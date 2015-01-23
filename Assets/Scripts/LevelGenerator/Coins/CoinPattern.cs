using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LevelGenerator.Coins
{
    class CoinPattern
    {
        private readonly ICollection<Vector2> m_coins; 
        public CoinPattern(ICollection<Vector2> coins)
        {
            m_coins = coins;
        } 

        public ICollection<Vector2> GetCoinsInPattern()
        {
            return m_coins;
        } 
    }
}
