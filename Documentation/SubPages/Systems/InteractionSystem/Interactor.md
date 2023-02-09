### [found in: Interaction System](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/InteractionSystem/InteractionSystem.md)
## Interactor
The interactor script can be attached to the object in order to allow it to interact.  
It has the following features:

- **On Can Interact** *UnityEvent*  
Event is Invoked when the interactor encounters an interactable and no other interactables are in range.

- **On Stop Can Intreact** *UnityEvent*  
Event is Invoked when the interactor moves out of range from an interactable and no other interactables are in range.

It has the following functions:

-**TryInteract**()  
Used to interact with a nearby *Interactable*.