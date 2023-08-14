using UnityEngine;
using UnityEngine.Events;

namespace DevKit {
    public class StatusEffectManager : MonoBehaviour
    {
        [SerializeField] private UnityDictionary<string, StatusEffect> statusEffects;

        public UnityEvent<StatusEffect> onStatusEffectAdded;
        public UnityEvent<StatusEffect> onStatusEffectRemoved;

        public void AddStacks(StatusEffect effect, int stacks)
        {
            if (statusEffects.ContainsKey(effect.effectName)) {
                statusEffects[effect.effectName].AddStacks(stacks);
            }
            else { //add new effect
                statusEffects.Add(effect.effectName, effect);
                effect.owner = this;
                effect.AddStacks(stacks);
                onStatusEffectAdded?.Invoke(effect);
            }
        }
        public void AddStacks(string effectName, int stacks)
        {
            if (statusEffects.ContainsKey(effectName)) {
                statusEffects[effectName].AddStacks(stacks);
            }
        }

        public void RemoveStacks(string effectName, int stacks)
        {
            if (statusEffects.ContainsKey(effectName)) {
                statusEffects[effectName].RemoveStacks(stacks);
                if (statusEffects[effectName].stacks <= 0) {
                    onStatusEffectRemoved?.Invoke(statusEffects[effectName]);
                    statusEffects.Remove(effectName);
                }
            }
        }

        public void ClearEffects()
        {
            foreach (StatusEffect effect in statusEffects.Values) {
                effect.RemoveStacks(effect.stacks);
                onStatusEffectRemoved?.Invoke(effect);
            }
            statusEffects.Clear();
        }

        public bool ContainsEffect(string effectName)
        {
            return statusEffects.ContainsKey(effectName);
        }
    }
}
