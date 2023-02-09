### [found in: Controllers](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Controllers.md)
## Drone Controller
A controller for 3 axis 3D movement.  
It has the following features:

- **Hor Top Speed** *float*  
Dictates the top speed on the horizontal axis.
- **Hor Acceleration** *float*  
Dictates how fast the controller reached max velocity on the horizontal axis.
- **Hor Deceleration** *float*  
Dictates how fast the controller slows down on the horizontal axis.
- **On Change Hor Move Dir** *UnityEvent\<Vector2\>*  
Event that is invoked when the horizontal move direction changes, passes *Vector2* move direction as a parameter.  

- **Ver Top Speed** *float*  
Dictates the top speed on the vertical axis.
- **Ver Acceleration** *float*  
Dictates how fast the controller reached max velocity on the vertical axis.
- **Ver Deceleration** *float*  
Dictates how fast the controller slows down on the vertical axis.
- **On Change Ver Move Dir** *UnityEvent\<Vector2\>*  
Event that is invoked when the vertical move direction changes, passes *float* move direction as a parameter 

It has the following functions:

- **SetHorMoveDir**(dir *Vector2*)  
Used to set which direction the controller should move in on the horizontal axis. The x value represents left to right and the y value forward to backward.

- **SetVerMoveDir**(dir *float*)  
used to set which direction the controller should move in on the vertical axis.