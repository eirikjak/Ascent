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
            //coinGenerator.AddRule(new RandomCoinGenerationRule(10, 0f, 2f));
            coinGenerator.AddRule(new PatternCoinGeneratorRule(10, 3f, CoinPatternFactory.GetPattern("box")));
            coinGenerator.AddRule(new PatternCoinGeneratorRule(10, 2f, CoinPatternFactory.GetPattern("line")));

            for (var i = 0; i < 1; i++)
            {
                foreach (var batch in coinGenerator.GetNextCoins())
                {
                    foreach (var coinPos in batch.Coins)
                    {
                        var coin = (GameObject)Instantiate(CoinPrefab);
                        coin.transform.position = coinPos;
                    }

                }
            }



        }
	
        // Update is called once per frame
        void Update () {
	
        }
    }
}
