using UnityEngine;
using DevKit;

public class WeightedChanceSample : MonoBehaviour
{
    [SerializeField] WeightedChance<string> logs;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log(logs.GetRandomEntry());
        }
    }
}
