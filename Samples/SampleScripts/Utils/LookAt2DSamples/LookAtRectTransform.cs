using UnityEngine;
using DevKit;

public class LookAtRectTransform : MonoBehaviour
{
    [SerializeField] private RectTransform lookAtTarget;

    private void Update()
    {
        transform.rotation = LookAt2D.LookAtRectTransform(transform, lookAtTarget);
    }
}
