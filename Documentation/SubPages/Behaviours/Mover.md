### [found in: Behaviours](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours.md)
## Mover
The mover moves the gameObject the behaviour is attached to in a predifined local direction. 
Use the *StartMove* and *StopMove* functions to start and end moving respectively.  
It has the following features:

- **Move Direction** *Vector3*  
Determines (in local space) which direction the object travels. This value is normalized on start.

- **Move Speed** *float*  
Determines how fast the object moves.

- **Move on Start** *bool*  
If set to true, start moving when *Start* is Invoked. When set to false, the object only starts moving after *StartMove* is Invoked.

It has the following functions:

- **StartMove**()  
Used to start moving.

- **StopMove**()  
Used to stop moving.