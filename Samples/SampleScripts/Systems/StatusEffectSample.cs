using UnityEngine;
using DevKit;

public class StatusEffectSample : MonoBehaviour
{
    public string effectName = "sample";
    public string message = "test";

    private StatusEffectManager effectManager;

    private void Start()
    {
        effectManager = GetComponent<StatusEffectManager>();
    }

    public void AddEffects(int count)
    {
        effectManager.AddStacks(new EffectSample(effectName, message), count);
    }

    public void RemoveEffects(int count)
    {
        effectManager.RemoveStacks("sample", count);
    }
}
