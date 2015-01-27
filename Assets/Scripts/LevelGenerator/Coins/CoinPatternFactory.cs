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
        private static readonly JSONNode s_shapes;
        private static readonly Dictionary<string, CoinPattern> s_parsedPatterns;
        private static readonly IDictionary<int, string> s_defaultNameMap;
        private static readonly float s_defaultCoinSpace;
        static CoinPatternFactory()
        {
            var config = JSON.Parse(Resources.Load<TextAsset>("coin_patterns").text);
            s_shapes = config["shapes"];
            s_defaultNameMap = ParseNameMap(config["default"]);
            s_defaultCoinSpace = ParseCoinSpace(config["default"]);
            s_parsedPatterns = new Dictionary<string, CoinPattern>();

            //Create the root items. Coins, platforms, powerups, etc.
            foreach (var generatorItem in GeneratorItems.Instance.Items)
            {
                var extents = generatorItem.Prefab.renderer.bounds.extents;
                extents.x *= generatorItem.Prefab.transform.localScale.x;
                extents.y *= generatorItem.Prefab.transform.localScale.y;
                s_parsedPatterns[generatorItem.Name] = new CoinPattern(new Coin(generatorItem.Name, 0, 0), extents.x * 2, extents.y * 2);
            }

        }

        public static CoinPattern GetPattern(string name)
        {
            if (s_parsedPatterns.ContainsKey(name))
            {
                return s_parsedPatterns[name];
            }
            
            ICollection<Tuple<Vector2, CoinPattern>> pattern;
            IDictionary<int, string> nameMap;
            float coinSpace;
            var currentPattern = s_shapes[name];

            if (currentPattern.ContainsKey("base"))
            {
                var basePattern = GetPattern(currentPattern["base"].Value);
                nameMap = currentPattern.ContainsKey("name_map") ? ParseNameMap(currentPattern) : basePattern.NameMap;
                pattern = currentPattern.ContainsKey("pattern") ? ParsePattern(currentPattern, nameMap) : basePattern.CoinPatternPatterns;
                coinSpace = currentPattern.ContainsKey("coin_space") ? ParseCoinSpace(currentPattern) : basePattern.CoinSpace;

            }
            else
            {
                coinSpace = ParseCoinSpace(currentPattern);
                nameMap = ParseNameMap(currentPattern);
                pattern = ParsePattern(currentPattern, nameMap);

            }

            var coinPattern = new CoinPattern(pattern, nameMap, coinSpace);
            s_parsedPatterns[name] = coinPattern;
            return coinPattern;
        }


        private static float ParseCoinSpace(JSONNode jsonNode)
        {
            if (jsonNode.ContainsKey("coin_space"))
            {
                return float.Parse(jsonNode["coin_space"].Value);
            }
            return s_defaultCoinSpace;

        }

        private static IDictionary<int, string> ParseNameMap(JSONNode shapeNode)
        {
            if (!shapeNode.ContainsKey("name_map")) return s_defaultNameMap;
            var nameMap = new Dictionary<int, string>();
            var mapNode = shapeNode["name_map"];
            foreach (var generatorItem in GeneratorItems.Instance.Items)
            {
                if (mapNode.ContainsKey(generatorItem.Name))
                {
                    nameMap.Add(mapNode[generatorItem.Name].AsInt, generatorItem.Name);
                }
                
            }
            return nameMap;
        }
        private static Collection<Tuple<Vector2, CoinPattern>> ParsePattern(JSONNode jsonNode, IDictionary<int, string> nameMap )
        {
            var jsonPattern = jsonNode["pattern"].AsArray;
            var pattern = new Collection<Tuple<Vector2, CoinPattern>>();  

            for (var i = 0; i < jsonPattern.Count; i++)
            {

                var row = jsonPattern[i];
                for (var j = 0; j < row.Count; j++)
                {
                    int value;
                    var name = row[j].Value;
                    if (Int32.TryParse(name, out value))
                    {
                        name = nameMap[value];
                    }
                    pattern.Add(new Tuple<Vector2, CoinPattern>(new Vector2(j, i), GetPattern(name)));
                    
                }
            }

            return pattern;
        } 
  
    }
}
