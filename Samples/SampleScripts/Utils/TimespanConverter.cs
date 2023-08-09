using UnityEngine;
using DevKit;

public class TimespanConverter : MonoBehaviour
{
    [SerializeField] private float seconds = 65.5f;
    [SerializeField] private string format = "mm':'ss";

    private void Update()
    {
        seconds -= Time.deltaTime;
        Debug.Log(TimeSpanConverter.SecondsToFormatString(seconds, format));
    }
}
