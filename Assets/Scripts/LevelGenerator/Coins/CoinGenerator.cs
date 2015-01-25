using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
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

        public IEnumerable<CoinBatch> GetNextCoins()
        {
            var batches = m_rules.Select(rule => rule.GetNext()).ToList();
            //For now use  the number of coins as a priority system.
            return batches.Where(batch => !batches.Any(coinBatch => batch.Bounds.Overlaps(coinBatch.Bounds) && !batch.Equals(coinBatch) && batch.Coins.Count < coinBatch.Coins.Count));

        } 
    }
}
