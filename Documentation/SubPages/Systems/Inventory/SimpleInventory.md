### [found in: Systems](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems.md)
## Simple Inventory
The Simple Inventory system can keep track of gaining and using items and keeps track of item counts. 
The system has no build in visuals. 
The simple inventory is not a Monobehaviour, to use it, add it as a variable to a different Monobehaviour.  
It has the following features:

- **inventory** *UnityDictionary*  
Dictionary of every item and their respective count.

It has the following functions:

- **UseItem**(item *T*, count *int*(optional)) returns *bool*  
This function is used to remove items from the inventory.  
The *item* parameter determines what item will be added to the inventory, it's type is set by the class.  
The *count* parameter determines how many of the *item* will be removed from the inventory. *count* is set to 1 by default.  
If the inventory has the item **and** has enough of the item, items will be removed and the function will return *true*, otherwise returns *false*.

- **GainItem**(item *T*, count *int*(optional))  
This function is used to add items to the inventory.  
The *item* parameter determines what item will be added to the inventory, it's type is set by the class.  
the *count* parameter determines how many of the *item* will be added to the inventory. *count* is set to 1 by default.