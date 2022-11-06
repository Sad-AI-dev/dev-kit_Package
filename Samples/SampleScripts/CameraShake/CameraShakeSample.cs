using UnityEngine;
using DevKit;

public class CameraShakeSample : MonoBehaviour
{
    [SerializeField] private CameraShaker shaker;
    [Header("Settings")]
    [SerializeField] private float duration = 1;
    [SerializeField] private float magnitude = 1;

    public void ShakeCamera()
    {
        shaker.ShakeCamera(duration, magnitude);
    }
}
