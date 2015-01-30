using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.LevelGenerator
{
    //The singleton is only there to please the Unity editor.
    [Serializable]
    public class GeneratorItems
    {
        public GeneratorItem[] Items;
        public static GeneratorItem[] LevelItems { get { return Instance.Items; } }
        public static GeneratorItems Instance { get; protected set; }
        private static IDictionary<string, GeneratorItem> s_itemLookup; 
        static GeneratorItems()
        {
            Instance = new GeneratorItems();
            
        }

        public static GeneratorItem GetItem(string name)
        {
            if (s_itemLookup != null) return s_itemLookup[name];

            s_itemLookup = new Dictionary<string, GeneratorItem>();
            foreach (var generatorItem in LevelItems)
            {
                s_itemLookup.Add(generatorItem.Name, generatorItem);
            }
            return s_itemLookup[name];
        }
        private GeneratorItems()
        {
            
        }
    }
}
