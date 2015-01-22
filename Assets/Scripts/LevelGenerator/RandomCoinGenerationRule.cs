using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Assets.Scripts.LevelGenerator
{
    class RandomCoinGenerationRule: CoinGenerationRule
    {

        private readonly float m_coinDistance;
        public RandomCoinGenerationRule(float sceneWidth, float initialHeight, float distance) : base(sceneWidth, initialHeight)
        {
            m_coinDistance = distance;
        }

        public override Vector2 GetNext()
        {
            var coinpos = new Vector2(Random.Range(0, SceneWidth), CurrentHeight);
            CurrentHeight += m_coinDistance;
            return coinpos;
        }
    }
}
