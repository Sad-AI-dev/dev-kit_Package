### [found in: Controllers](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Controllers.md)
## Top Down Controller
A controller with simple top down 2D controls.  
It has the following features:

- **Top Speed** *float*  
Dictates the max velocity.
- **Acceleration** *float*  
Dictates how fast the controller reached top speed.

- **On Change Move Dir** *UnityEvent\<Vector2\>*  
Event that is invoked when the move direction chances, passes Vector2 move direction as a parameter.

- **Mode** *enum*  
Determines the way movement is handled. Has 3 modes:
    - *Set Position*: Directly sets the position of the controller.
    - *Set Velocity*: Directly sets the velocity of the rigidbody2D attached to the object.
    - *Use Force*: Uses the AddForce function on the rigidbody2D attached to the object.
    
It has the following functions:

- **SetMoveDir**(input *Vector2*)  
Used to set which direction the controller should move in.