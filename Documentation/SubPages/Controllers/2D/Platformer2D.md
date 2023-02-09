### [found in: Controllers](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Controllers.md)
## Platformer 2D
A controller with simple 2D platforming controls.  
It has the following features:

- **Top Speed** *float*  
Dictates the max velocity.
- **Acceleration** *float*  
Dictates how fast the controller reached max velocity.
- **Deceleration** *float*  
Dictates how fast the controller slows down.
- **Facing Left** *bool*  
Determines which way the controller is facing, can be used to set the starting facing direction.  
Use *IsFacingLeft* to check if controller is facing left, cannot be set.

- **Jump Height** *float*  
Dictates how high the controller jumps.
- **Rise Grav** *float*  
Sets the gravity while rising during a jump. This gravity will be used until the jump button is released or the jump reached the peak of its arc.
- **Fall Grav** *float*  
Sets the gravity while falling during a jump.  

- **Jump Buffer Time** *float*  
Dictates the size of the jump input buffer. Jump buffer is used to allow the controller to retroactively jump if they input jump a bit before landing.
- **Coyote Time** *float*  
Dictates the length of coyote time. Coyote time allows the controller to jump just after falling off a platform.  

- **Ground Detector** *GroundDetector2D*  
A reference to the ground detector that should be used.

It has the following functions:

- **SetMoveDir**(input *float*)  
Used to set which direction the controller should move in. Also accepts *Vector2* as input, y value is ignored.

- **StartJump**()  
Used to start a jump, recommended to be bound to an OnButtonDown event.

- **EndJump**()  
Used to end a jump. Activates the fall grav. Recommended to be bound to an OnButtonUp event.