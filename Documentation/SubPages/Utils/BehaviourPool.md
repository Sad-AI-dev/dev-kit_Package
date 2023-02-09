### [found in: Utils](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Utils.md)
## Behaviour Pool
A class for managing a reusable pool of MonoBehaviours.  
To mark a MonoBehaviour ready to be reused, the GameObject the MonoBehviour is attached to must be set to inactive, like this:
```
myBehaviour.gameObject.SetActive(false);
```
It has the following features:

- **prefab** *GameObject*  
The prefab to be created when no behaviour is available for reuse.

- **targetHolder** *Transform*  
The transform to be used as a parent for a newly created object.  
If left as null, newly created objects will not have a parent object.

- **pool** *List\<T\>*  
List of behaviours that can be reused.  
Typically left empty, but can be prefilled with behaviours.

It has the following functions:

- **GetBehaviour**() returns *T*  
Either returns a behaviour marked ready for reuse, or creates a new behaviour and adds it to the pool if none are available.

### Variant: Object pool
A variation of the Behaviour pool. Instead of tracking MonoBehaviours, it tracks GameObjects.  
This class does not have the **GetBehaviour** function, but instead has the **GetObject** function, which functions the same.