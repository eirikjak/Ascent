using Assets.Scripts.LevelGenerator.Coins;
using UnityEngine;

namespace Assets.Scripts.LevelGenerator
{
    public class LevelGenerator : MonoBehaviour
    {
        public GameObject PlatformPrefab;
        public GameObject CoinPrefab;
        // Use this for initialization
        public Vector2 MaxPlatformDistance;
        public Vector2 MinPlatformDistance;
        void Start ()
        {
            var test = (GameObject) Instantiate(PlatformPrefab);
            var width = test.collider2D.bounds.extents.x;
            Destroy(test);
            var generator = new PlatformGenerator(10, new[] { width }, MinPlatformDistance, MaxPlatformDistance);
            for (var i = 0; i < 100; i++)
            {
                var platform = (GameObject)Instantiate(PlatformPrefab);
                platform.transform.position = generator.GetNextPlatformPosition(); 
            }

            var coinGenerator = new CoinGenerator();
            coinGenerator.AddRule(new RandomCoinGenerationRule(10, 0f, 2f));
            coinGenerator.AddRule(new PatternCoinGeneratorRule(10, 2f, CoinPatternFactory.GetPattern("line")));
            coinGenerator.AddRule(new PatternCoinGeneratorRule(10, 2f, CoinPatternFactory.GetPattern("box")));
            for (var i = 0; i < 100; i++)
            {
                foreach (var coinPos in coinGenerator.GetNextCoins())
                {
                    var coin = (GameObject)Instantiate(CoinPrefab);
                    coin.transform.position = coinPos;
                }
            }



        }
	
        // Update is called once per frame
        void Update () {
	
        }
    }
}
