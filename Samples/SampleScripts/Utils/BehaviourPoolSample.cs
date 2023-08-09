using UnityEngine;
using DevKit;

public class BehaviourPoolSample : MonoBehaviour
{
    public BehaviourPool<LifeTime> samplePool;

    public void CreateObject()
    {
        LifeTime lifeTime = samplePool.GetBehaviour();
        lifeTime.transform.position = transform.position;
        lifeTime.transform.localRotation = Quaternion.identity;
    }
}
