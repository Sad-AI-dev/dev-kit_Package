### [found in: Controllers](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Controllers.md)
## Platformer 3D Character Controller
A controller for 3D platforming using the Character Controller component.  
It has the following features:

- **Top Speed** *float*  
Dictates the top speed.
- **Acceleration** *float*  
Dictates how fast the controller reached max velocity.
- **Deceleration** *float*  
Dictates how fast the controller slows down.
- **On Change Move Dir** *UnityEvent\<Vector2\>*  
Event that is invoked when the move direction chances, passes Vector2 move direction as a parameter.  

- **Jump Height** *float*  
Dictates how high the controller jumps.  
- **Gravity** *float*  
Dictates the gravity on the controller.

- **Jump Buffer Time** *float*  
Dictates the size of the jump input buffer. Jump buffer is used to allow the controller to retroactively jump if they input jump a bit before landing.
- **Coyote Time** *float*  
Dictates the length of coyote time. Coyote time allows the controller to jump just after falling off a platform.  

It has the following functions:

- **SetMoveDir**(input *Vector2*)  
Used to set which direction the controller should move in.

- **Jump**()  
Used to jump.