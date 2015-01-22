using UnityEngine;

namespace Assets.Scripts.LevelGenerator
{
    public class LevelGenerator : MonoBehaviour
    {
        public GameObject PlatformPrefab;
        // Use this for initialization
        public Vector2 MaxPlatformDistance;
        public Vector2 MinPlatformDistance;
        void Start ()
        {
            var test = (GameObject) Instantiate(PlatformPrefab);
            var width = test.collider2D.bounds.extents.x;
            Destroy(test);
            var generator = new PlatformGenerator(7, new[] { width }, MinPlatformDistance, MaxPlatformDistance);
            for (var i = 0; i < 100; i++)
            {
                var platform = (GameObject)Instantiate(PlatformPrefab);
                platform.transform.position = generator.GetNextPlatformPosition(); 
            }


        }
	
        // Update is called once per frame
        void Update () {
	
        }
    }
}
