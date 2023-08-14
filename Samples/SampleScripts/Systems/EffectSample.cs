using System.Collections;
using UnityEngine;
using DevKit;

[System.Serializable]
public class EffectSample : StatusEffect
{
    private readonly string message;
    private Coroutine effectRoutine;

    public EffectSample(string effectName, string message) : base(effectName)
    {
        this.message = message;
    }

    protected override void OnAddEffect()
    {
        effectRoutine = owner.StartCoroutine(LogCo());
    }

    protected override void OnRemoveEffect()
    {
        owner.StopCoroutine(effectRoutine);
    }

    protected override void OnAddStack() { }
    protected override void OnRemoveStack() { Debug.Log("Removed Stack"); }

    //=========== Effect ============
    private IEnumerator LogCo()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < stacks; i++) {
            Debug.Log(message + " stacks left: " + stacks);
        }
        effectRoutine = owner.StartCoroutine(LogCo());
        owner.RemoveStacks(effectName, 1); //lose stacks over time
    }
}
