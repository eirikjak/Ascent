﻿using System;
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
            var jsonPattern = s_patterns[name]["pattern"].AsArray;
            var coin_space = float.Parse(s_patterns[name]["coin_space"].Value);
            var pattern = new Collection<Vector2>();
            for (var i = 0; i < jsonPattern.Count; i++)
            {
               
                var row = jsonPattern[i];
                for (var j = 0; j < row.Count; j++)
                {
                    if(Int32.Parse(row[j].Value) > 0)
                        pattern.Add(new Vector2(j*coin_space, i*coin_space));
                   
                }
            }
            var width = pattern.Max(coins => coins.x + 1)*coin_space;
            var height = pattern.Max(coins => coins.y +1)*coin_space;
            var coinPattern = new CoinPattern(pattern, new Rect(0, 0, width, height));
            
            s_parsedPatterns[name] = coinPattern;
            return coinPattern;
        }
    }
}
