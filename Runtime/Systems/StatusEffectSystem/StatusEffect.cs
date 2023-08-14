namespace DevKit {
    [System.Serializable]
    public abstract class StatusEffect
    {
        public readonly string effectName;
        public int stacks;
        public StatusEffectManager owner;

        public StatusEffect(string effectName)
        {
            this.effectName = GetValidName(effectName);
            stacks = 0;
        }
        private string GetValidName(string name)
        {
            if (name != null) {
                return name;
            }
            else return "";
        }

        public void AddStacks(int stacksToAdd)
        {
            if (stacks == 0) { OnAddEffect(); }
            stacks += stacksToAdd;
            for (int i = 0; i < stacksToAdd; i++) {
                OnAddStack();
            }
        }

        public void RemoveStacks(int stacksToRemove)
        {
            for (int i = 0; i < stacksToRemove && stacks > 0; i++) {
                OnRemoveStack();
                stacks--;
            }
            if (stacks <= 0) { 
                OnRemoveEffect();
            }
        }

        protected abstract void OnAddEffect();
        protected abstract void OnRemoveEffect();

        protected abstract void OnAddStack();
        protected abstract void OnRemoveStack();
    }
}
