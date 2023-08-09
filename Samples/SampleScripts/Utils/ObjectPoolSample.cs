using UnityEngine;
using DevKit;

public class ObjectPoolSample : MonoBehaviour
{
    public ObjectPool objectPool;

    public void SpawnObject()
    {
        GameObject obj = objectPool.GetObject();
        obj.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
}
