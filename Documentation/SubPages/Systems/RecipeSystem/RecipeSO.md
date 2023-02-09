#### Category/System
## Recipe SO
The Recipe SO holds the information that makes up a recipe. 
The recipe processer uses these to process inputs and return an output if inputs are valid.  
To use the recipe SO, create a class that inherits from the recipe SO with the desired variable types, like this:
```
[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Recipe")]
public class MyRecipeSO : RecipeSO<string, string> {

}
```
The Recipe SO has the following features:

- **Inputs** *List\<Input\>*  
The type is determined by the inheritor class. Stores the inputs in the recipe that result in the output. 
When *TryRecipe* is Invoked with these inputs, output will be returned.

- **Perfect Match** *bool*  
If set to true, the order in which the inputs are submitted when *TryRecipe* is Invoked, needs to perfectly match the inputs list on the recipe. 
When set to false, the order of the inputs doesn't matter.

- **Ouput** *Output*  
The type is determined by the inheritor class. Output gets returned when *TryRecipe* is Invoked and the input is valid.