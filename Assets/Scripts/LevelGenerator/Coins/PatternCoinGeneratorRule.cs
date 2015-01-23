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

        public override ICollection<Vector2> GetNext()
        {
            var coins = m_pattern.GetCoinsInPattern().Select(pos => new Vector2(pos.x, pos.y + CurrentHeight)).ToList();
            return coins;
        }
    }
}
