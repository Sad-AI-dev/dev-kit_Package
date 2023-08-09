using UnityEngine;
using DevKit;

public class WeightedChanceSample : MonoBehaviour
{
    [SerializeField] private WeightedChance<string> logs;

    public void GetRandomEntry()
    {
        Debug.Log(logs.GetRandomEntry());
    }
}
