using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.LevelGenerator.Coins
{
    class PatternCoinGeneratorRule: CoinGenerationRule
    {
        private readonly CoinPattern m_pattern;
        public PatternCoinGeneratorRule(float sceneWidth, float initialHeight, CoinPattern pattern) : base(sceneWidth, initialHeight)
        {
            m_pattern = pattern;
        }

        public override CoinBatch GetNext()
        {
            var coins = m_pattern.Coins.Select(coin => new Coin(coin.Name, coin.x, coin.y + CurrentHeight)).ToList();
            Debug.Log(m_pattern.Bounds);
            return new CoinBatch
            {
                Coins = coins,
                Bounds = new Rect(0, CurrentHeight, m_pattern.Bounds.width, m_pattern.Bounds.height)
            };
        }
    }
}
