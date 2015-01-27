using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Util;
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
            s_parsedPatterns["coin"] = new CoinPattern(new Coin(CoinType.Regular, 0, 0), 0.6f);
        }

        public static CoinPattern GetPattern(string name)
        {
            if (s_parsedPatterns.ContainsKey(name))
            {
                return s_parsedPatterns[name];
            }
            
            int value;
            if (Int32.TryParse(name, out value))
            {
                return value > 0 ? s_parsedPatterns["coin"] : s_parsedPatterns["empty"];

            }
            ICollection<Tuple<Vector2, CoinPattern>> pattern;
            float coinSpace;
            var currentPattern = s_patterns[name];

            if (currentPattern.ContainsKey("base"))
            {
                var basePattern = GetPattern(currentPattern["base"].Value);
                pattern = currentPattern.ContainsKey("pattern")
                    ? ParsePattern(currentPattern)
                    : basePattern.CoinPatternPatterns;
                coinSpace = currentPattern.ContainsKey("coin_space")
                    ? ParseCoinSpace(currentPattern)
                    : basePattern.CoinSpace;

            }
            else
            {
                coinSpace = ParseCoinSpace(currentPattern);
                pattern = ParsePattern(currentPattern);
            }

            var coinPattern = new CoinPattern(pattern, coinSpace);
            s_parsedPatterns[name] = coinPattern;
            return coinPattern;
        }


        private static float ParseCoinSpace(JSONNode jsonNode)
        {
            return float.Parse(jsonNode["coin_space"].Value);
        } 
        private static Collection<Tuple<Vector2, CoinPattern>> ParsePattern(JSONNode jsonNode)
        {
            var jsonPattern = jsonNode["pattern"].AsArray;
            var pattern = new Collection<Tuple<Vector2, CoinPattern>>();  

            for (var i = 0; i < jsonPattern.Count; i++)
            {

                var row = jsonPattern[i];
                for (var j = 0; j < row.Count; j++)
                {
                        pattern.Add(new Tuple<Vector2, CoinPattern>(new Vector2(j, i), GetPattern(row[j].Value)));
                    
                }
            }

            return pattern;
        } 
  
    }
}
