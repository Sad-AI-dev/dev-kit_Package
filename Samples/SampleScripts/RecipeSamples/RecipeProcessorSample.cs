using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeProcessorSample : MonoBehaviour
{
    [SerializeField] private RecipeProcessor<string, string> recipeProcessor;

    [SerializeField] private List<string> inputs;

    private void Start()
    {
        Debug.Log(recipeProcessor.TryRecipe(inputs));
    }
}
