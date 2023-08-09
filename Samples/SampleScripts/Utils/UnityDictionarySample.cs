using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class UnityDictionarySample : MonoBehaviour
{
    [SerializeField] private UnityDictionary<int, string> names;

    private void Start()
    {
        foreach (KeyValuePair<int, string> pair in names) {
            Debug.Log(pair.Key + ": " + pair.Value);
        }
    }
}
