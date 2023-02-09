### [found in: Behaviours](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours.md)
## LifeTime
The life time behaviour deactivates or destroys a gameobject after a set time.  
It has the following features:

- **Life Time** *float*:  
Determines how long, in seconds, before the object is destroyed or deactivated.

- **Destroy On Life Time End** *bool*:  
When set to *true*, the game object will be destroyed when the timer runs out.  
When set to *false*, the game object will be disabled when the timer runs out.

- **On Life Time End** *UnityEvent*:  
This event is invoked when the timer runs out.