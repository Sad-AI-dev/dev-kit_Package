### [found in: Utils](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Utils.md)
## Option Picker
A class for chosing an option from a list.  
It has the following features:

- **selectMode** *enum*  
Determines how options are selected.  
Has the following options:
    - *Random*: option is selected randomly.
    - *Round_Robin*: options is selected in order, starting at index 0 and ending at the end of the list, then looping back to 0 again.

- **options** *WeightedChance\<T\>*  
Options that the class can pick from.

It has the following functions:

- **GetOption**() returns *T*  
Returns an option, which is picked according to *selectMode*.

- **GetOptionAtIndex**(index *int*) returns *T*  
Returns the option at *index*.