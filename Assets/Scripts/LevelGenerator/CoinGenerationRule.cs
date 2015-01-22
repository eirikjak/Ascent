using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.LevelGenerator
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
        public abstract Vector2 GetNext();
    }
}
