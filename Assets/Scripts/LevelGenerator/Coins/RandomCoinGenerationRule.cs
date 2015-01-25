using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.LevelGenerator.Coins
{
    class RandomCoinGenerationRule: CoinGenerationRule
    {

        private readonly float m_coinDistance;
        public RandomCoinGenerationRule(float sceneWidth, float initialHeight, float distance) : base(sceneWidth, initialHeight)
        {
            m_coinDistance = distance;
        }

        public override CoinBatch GetNext()
        {
            var coinpos = new Vector2(Random.Range(0, SceneWidth), CurrentHeight);
            CurrentHeight += m_coinDistance;
            return new CoinBatch
            {
                Coins = new[] {coinpos},
                Bounds = new Rect(0, 0, 0.6f, 0.6f)
            };
        }
    }
}
