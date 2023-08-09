using UnityEngine;
using DevKit;

public class CollectionUtilSample : MonoBehaviour
{
    public UnityDictionary<string, int> dictionary;

    public void TryGetKeyFromValue(int value)
    {
        Debug.Log(CollectionUtils.GetKeyFromValue<string, int>(dictionary, value));
    }

    public void GetRandomEntry()
    {
        Debug.Log(CollectionUtils.GetRandomEntry<string, int>(dictionary));
    }
}
