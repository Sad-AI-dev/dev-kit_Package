using UnityEngine;
using DevKit;

public class LookAtMouse : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = LookAt2D.LookAtMouse(transform);
    }
}
