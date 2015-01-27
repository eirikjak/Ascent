using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.LevelGenerator
{
    [Serializable]
    public class GeneratorItems
    {
        public GeneratorItem[] Items;
        public static GeneratorItems Instance { get; protected set; }
        static GeneratorItems()
        {
            Instance = new GeneratorItems();
            ;
        }

        private GeneratorItems()
        {
            
        }
    }
}
