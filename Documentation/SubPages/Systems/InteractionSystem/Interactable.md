### [found in: Interaction System](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/InteractionSystem/InteractionSystem.md)
### Interactable
The Interactable script can be attached to an object to allow it to be interacted with. 
If the interactable needs the be destroyed, use the *DestroyInteractable* function. 
In order to function, the interactable needs a trigger collider to detect interactors.  
It has the following features:

- **On Interact** *UnityEvent\<Interactor\>*  
Identical to On Interact Void, but passes the interactor that interacted with the object as a parameter.