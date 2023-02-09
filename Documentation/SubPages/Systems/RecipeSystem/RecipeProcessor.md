### [found in: Recipe System](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/RecipeSystem/RecipeSystem.md)
## Recipe Processor
The recipe processor holds recipes, use the *TryRecipe* to get a result output if the recipe is valid. 
The recipe processor is not a Monobehaviour, to use it, add it as a variable to a different Monobehaviour.  
It has the following features:

- **Recipes** *List\<RecipeSO\>*  
The list of recipes referenced by the recipe processor.

It has the following functions:

- **TryRecipe**(inputs *List\<Input\>*) return *Output*  
Input type and Output type are determined by the class implementing the recipe processor.  
Takes a list of inputs and checks if it is a valid recipe. Returns the output is it is valid, returns *default* if not.