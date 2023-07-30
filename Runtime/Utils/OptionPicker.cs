

namespace DevKit {
    [System.Serializable]
    public class OptionPicker<T>
    {
        public enum OptionSelectMode { Random, Round_Robin }

        public OptionSelectMode selectMode;
        public WeightedChance<T> options;
        //vars
        private int roundRobinIndex = -1;

        public T GetOption()
        {
            return selectMode switch {
                OptionSelectMode.Round_Robin => GetRoundRobinEntry(),
                _ => GetRandomEntry(),
            };
        }

        private T GetRandomEntry()
        {
            return options.GetRandomEntry();
        }

        private T GetRoundRobinEntry()
        {
            roundRobinIndex++;
            if (roundRobinIndex >= options.Count) { roundRobinIndex = 0; }
            return options.options[roundRobinIndex].option;
        }

        //============ set index ============
        public T GetOptionAtIndex(int index)
        {
            return options.options[index].option;
        }
    }
}
