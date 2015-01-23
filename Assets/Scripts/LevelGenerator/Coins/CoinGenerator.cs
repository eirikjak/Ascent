using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.LevelGenerator.Coins
{
    class CoinGenerator
    {
        private readonly ICollection<CoinGenerationRule> m_rules;

        public CoinGenerator()
        {
            m_rules = new Collection<CoinGenerationRule>();
        }
        public void AddRule(CoinGenerationRule rule)
        {
            m_rules.Add(rule);
        }

        public IEnumerable<Vector2> GetNextCoins()
        {
            return m_rules.SelectMany(rule => rule.GetNext());
        } 
    }
}
