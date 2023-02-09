### [found in: Behaviours](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours.md)
## UI Toggle Mover
Used to move the rect transform that the toggle mover is attached to between two defined positions, 
the position of the rect transform is considered the start position on *Start*.  
It has the following features:

- **End Position** *RectTransform*  
Destination to travel towards.

- **Move Mode** *enum*  
Dictates how the rect transform travels to the target destination, has the following options:
    - *Linear*: Moves towards the target destination linearly.
    - *Lerp*: Moves towards the target smoothly using linear interpolation.
    
- **Move Speed** *float*  
Determines how fast the rect transform travels.

- **Move on Start** *bool*  
When set to true, the object will start moving when *Start* is Invoked. When false, this does nothing.

It has the following functions:

- **StartMove**()  
Used to start moving to the other destination.