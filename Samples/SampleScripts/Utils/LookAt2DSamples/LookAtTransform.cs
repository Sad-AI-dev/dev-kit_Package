using UnityEngine;
using DevKit;

public class LookAtTransform : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;

    private void Update()
    {
        transform.rotation = LookAt2D.LookAtTransform(transform, targetTransform.position);
    }
}
