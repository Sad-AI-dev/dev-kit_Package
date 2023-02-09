using UnityEngine;
using DevKit;

public class TimespanConverter : MonoBehaviour
{
    [SerializeField] private float seconds = 65.5f;

    private void Start()
    {
        Debug.Log(TimeSpanConverter.SecondsToFormatString(seconds));
    }
}
