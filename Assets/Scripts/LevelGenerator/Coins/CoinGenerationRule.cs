using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LevelGenerator.Coins
{
    abstract class CoinGenerationRule
    {
        protected float SceneWidth;
        protected float CurrentHeight;
        protected float Density;
        protected CoinGenerationRule(float sceneWidth, float initialHeight)
        {
            SceneWidth = sceneWidth;
            CurrentHeight = initialHeight;
        }
        public abstract CoinBatch GetNext();
    }
}
