using System;
using System.Collections.Generic;
using UnityEngine;

namespace DevKit {
[Serializable]
public class UnityDictionary<Key, Value> : ISerializationCallbackReceiver
{
    [System.Serializable]
    public struct Pair {
        public Key key;
        public Value value;
    }

    [SerializeField] private List<Pair> dictionary;

    public Dictionary<Key, Value> dict = new Dictionary<Key, Value>();

    //----------------serialization--------------------
    //dictionary to lists
    public void OnBeforeSerialize() {
        if (dict != null && ListIsValid()) {
            dictionary.Clear();
            //populate list
            foreach (var kvp in dict) {
                dictionary.Add(new Pair { key = kvp.Key, value = kvp.Value });
            }
        }
    }

    //lists to dictionary
    public void OnAfterDeserialize()
    {
        dict = new Dictionary<Key, Value>();

        for (int i = 0; i < dictionary.Count; i++) {
            dict.Add(dictionary[i].key, dictionary[i].value);
        }
    }

    //-----------valid lists check------------
    private bool ListIsValid()
    {
        List<Key> keys = new List<Key>();
        foreach (Pair pair in dictionary) {
            if (keys.Contains(pair.key)) {
                return false; //duplicate key found
            }
            keys.Add(pair.key); //register key
        }
        return true; //no duplicate keys found
    }
}
}
