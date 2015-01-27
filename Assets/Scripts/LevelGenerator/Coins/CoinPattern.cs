using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using Assets.Scripts.Util;
using UnityEngine;

namespace Assets.Scripts.LevelGenerator.Coins
{
    class CoinPattern
    {
        private readonly ICollection<Tuple<Vector2, CoinPattern>> m_coinPatterns;
        private readonly ICollection<Vector2> m_coinPositions;
        public IDictionary<int, string> NameMap { get; protected set; } 
        public Rect Bounds { get; protected set; }
        public float CoinSpace { get; protected set; }
        public ICollection<Tuple<Vector2, CoinPattern>> CoinPatternPatterns { get { return m_coinPatterns; }}
        public ICollection<Coin> Coins { get; protected set; } 
        public ICollection<Vector2> CoinPositions { get { return m_coinPositions; } }

        public CoinPattern(Coin coin, float width, float height)
        {
            Coins = new Collection<Coin>()
            {
                coin
            };
            Bounds = new Rect(0, 0, width, height);
            Debug.Log(Bounds);
            m_coinPatterns = new Collection<Tuple<Vector2, CoinPattern>>
            {
                new Tuple<Vector2, CoinPattern>(new Vector2(0, 0), this)
            };
            m_coinPositions = new Collection<Vector2>()
            {
                new Vector2(0, 0)
            };
            
        }
        public CoinPattern(ICollection<Tuple<Vector2, CoinPattern>> coinPatterns, IDictionary<int, string> nameMap, float coinSpace)
        {
            m_coinPatterns = coinPatterns;
            NameMap = nameMap;
            CoinSpace = coinSpace;
            Coins = new Collection<Coin>();
            var offset = Vector2.zero;
            var largestX = 0f;
            var largestY = 0f;
            foreach (var tuple in coinPatterns)
            {
                offset.x = largestX;
                var patternPosition = tuple.First;
                if ((int)patternPosition.x == 0)
                {
                    if (offset.x > 0)
                        offset.y = largestY + CoinSpace;
                    offset.x = 0;
                    largestX = 0f;
                    largestY = 0f;
                }
                foreach (var coin in tuple.Second.Coins)
                {
                    var x = coin.x + offset.x;
                    var y = coin.y + offset.y;
                    Coins.Add(new Coin(coin.Name, x, y));
                    largestX = Math.Max(x, largestX);
                    largestY = Math.Max(y, largestY);
                }
                largestX += CoinSpace;
            }
            var width = Coins.Max(coin => coin.x + CoinPatternFactory.GetPattern(coin.Name).Bounds.width / 2);
            var height = Coins.Max(coin => coin.y + CoinPatternFactory.GetPattern(coin.Name).Bounds.height / 2);
            Bounds = new Rect(0, 0, width, height);

        }


    }
}
