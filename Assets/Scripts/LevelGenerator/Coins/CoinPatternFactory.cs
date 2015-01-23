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
            var jsonPattern = s_patterns[name].AsArray;
            var pattern = new Collection<Vector2>();
            for (var i = 0; i < jsonPattern.Count; i++)
            {
               
                var row = jsonPattern[i];
                for (var j = 0; j < row.Count; j++)
                {
                    if(Int32.Parse(row[j].Value) > 0)
                        pattern.Add(new Vector2(j, i));
                   
                }
            }
            var coinPattern = new CoinPattern(pattern);
            ;
            s_parsedPatterns[name] = coinPattern;
            return coinPattern;
        }
    }
}
