### [found in: Utils](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Utils.md)
## Weighted Chance
A class for handling weighted random chances.  
Each option in weighted chance has the following features:  

- **option** *T*  
The option to be returned when entry is chosen.

- **chance** *float*  
The comparative chance of option being chosen.  
Example: entry 1 with chance = 3, and entry 2 with chance = 1. In this example, entry 1 would have a 75% chance of being chosen and entry 2 would have a 25% chance.

It has the following features:  

- **Count** *int*  
The amount of options.

It has the following functions:

- **GetRandomEntry**() returns *T*  
Returns random entry from *chances* using weighted chance.  
Retrun type is determined by class.  
Example code:
```
public class MyClass {

    public WeightedChance<string> chances;
    
    //function is externally called by, for example, a UnityEvent
    public void ChooseOption() {
        Debug.Log(chances.GetRandomEntry()); //gets a random entry and logs result
    }
}
```

- **GetEntry**(index *int*) returns *T*  
Returns the entry at *index*.

- **AddOption**(option *WeightedOption*)  
Adds a new option to the list.

- **RemoveOption**(option *WeightedOption*)
Removes an option from the list.