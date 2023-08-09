using System.Collections.Generic;
using UnityEngine;

namespace DevKit {
    public class CollectionUtils
    {
        //=================== Key from Value ===================
        public static Key GetKeyFromValue<Key, Value>(Dictionary<Key, Value> dictionary, Value value)
        {
            foreach (var pair in dictionary) {
                if (pair.Value.Equals(value)) {
                    return pair.Key;
                }
            }
            return default;
        }
        //=================== Get Random Entry ===================
        public static T GetRandomEntry<T>(IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static T GetRandomEntry<T>(T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }

        public static KeyValuePair<Key,Value> GetRandomEntry<Key, Value>(Dictionary<Key, Value> dictionary)
        {
            int randIndex = Random.Range(0, dictionary.Count);
            foreach (var pair in dictionary) {
                if (randIndex <= 0) { return pair; }
                randIndex--;
            }
            return default; //should never happen...
        }
    }
}
