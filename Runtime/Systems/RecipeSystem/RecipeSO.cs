using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeSO<Input, Output> : ScriptableObject
{
    public List<Input> inputs;
    [Tooltip("Dictates if the order of inputs matters.\nWhen set to true, the order must match")]
    public bool perfectMatch = true;
    [Space(10)]
    public Output output;
}
