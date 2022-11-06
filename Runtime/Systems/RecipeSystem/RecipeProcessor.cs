using System.Linq;
using System.Collections.Generic;

namespace DevKit {
    [System.Serializable]
    public class RecipeProcessor<Input, Output>
    {
        public List<RecipeSO<Input, Output>> recipes;

        public Output TryRecipe(List<Input> inputs)
        {
            foreach (RecipeSO<Input, Output> recipe in recipes) {
                if (inputs.Count == recipe.inputs.Count) {
                    if (RecipeCheck(inputs, recipe)) {
                        return recipe.output;
                    }
                }
            }
            return default;
        }

        private bool RecipeCheck(List<Input> inputs, RecipeSO<Input, Output> recipe)
        {
            if (recipe.perfectMatch) {
                //deep compare
                return Enumerable.SequenceEqual(inputs, recipe.inputs);
            }
            else {
                //check for elements only found in inputs
                List<Input> onlyInInput = inputs.Where(input => !recipe.inputs.Contains(input)).ToList();
                if (onlyInInput.Count > 0) { return false; }
                //check for elements only found in recipe
                List<Input> onlyInRecipe = recipe.inputs.Where(input => !inputs.Contains(input)).ToList();
                return onlyInRecipe.Count <= 0;
            }
        }
    }
}
