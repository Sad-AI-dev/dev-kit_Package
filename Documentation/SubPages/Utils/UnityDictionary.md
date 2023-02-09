### [found in: Utils](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Utils.md)
## Unity Dictionary
A class that integrates the Dictionary class into the unity editor.  
The class can be directly interfaced with, following the same patterns as the c# Dictionary class.  
Some examples are:  
```
UnityDictionary<string, string> myUnityDict;
//loop over dict
foreach (KeyValuePair<string, string> pair in myUnityDict) {
    //execute code per pair here
}

//get specific index
string value = myUnityDict["myKey"];
```