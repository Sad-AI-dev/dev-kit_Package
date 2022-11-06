using UnityEngine;
using DevKit;

public class UnityDictionarySample : MonoBehaviour
{
    [SerializeField] private UnityDictionary<int, string> names;

    private void Start()
    {
        foreach (var pair in names.dict) {
            Debug.Log(pair.Key + ": " + pair.Value);
        }
    }
}
