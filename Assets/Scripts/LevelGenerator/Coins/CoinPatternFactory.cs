using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SimpleJSON;
using UnityEngine;

namespace Assets.Scripts.LevelGenerator.Coins
{
    class CoinPatternFactory
    {
        private static readonly JSONNode s_patterns;
        private static readonly Dictionary<string, CoinPattern> s_parsedPatterns; 
        static CoinPatternFactory()
        {

            s_patterns = JSON.Parse(Resources.Load<TextAsset>("coin_patterns").text);
            s_parsedPatterns = new Dictionary<string, CoinPattern>();
        }

        public static CoinPattern GetPattern(string name)
        {
            if (s_parsedPatterns.ContainsKey(name))
            {
                return s_parsedPatterns[name];
            }
            ICollection<Vector2> pattern;
            float coinSpace;
            var currentPattern = s_patterns[name];

            if (currentPattern.ContainsKey("base"))
            {
                var basePattern = GetPattern(currentPattern["base"].Value);
                pattern = currentPattern.ContainsKey("pattern")
                    ? ParsePattern(currentPattern)
                    : basePattern.CoinsInPattern;
                coinSpace = currentPattern.ContainsKey("coin_space")
                    ? ParseCoinSpace(currentPattern)
                    : basePattern.CoinSpace;

            }
            else
            {
                coinSpace = ParseCoinSpace(currentPattern);
                pattern = ParsePattern(currentPattern);
            }
           
            var coinPattern = CreateCoinPattern(pattern, coinSpace);
            s_parsedPatterns[name] = coinPattern;
            return coinPattern;
        }

        private static CoinPattern CreateCoinPattern(ICollection<Vector2> pattern, float coin_space)
        {
            var width = pattern.Max(coins => coins.x + 1) * coin_space;
            var height = pattern.Max(coins => coins.y + 1) * coin_space;

            return new CoinPattern(pattern, new Rect(0, 0, width, height), coin_space);
        }
        private static float ParseCoinSpace(JSONNode jsonNode)
        {
            return float.Parse(jsonNode["coin_space"].Value);
        } 
        private static ICollection<Vector2> ParsePattern(JSONNode jsonNode)
        {
            var jsonPattern = jsonNode["pattern"].AsArray;
            var pattern = new Collection<Vector2>();
            for (var i = 0; i < jsonPattern.Count; i++)
            {

                var row = jsonPattern[i];
                for (var j = 0; j < row.Count; j++)
                {
                    if (Int32.Parse(row[j].Value) > 0)
                        pattern.Add(new Vector2(j, i));

                }
            }
            return pattern;
        } 
  
    }
}
