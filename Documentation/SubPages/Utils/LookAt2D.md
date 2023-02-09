### [found in: Utils](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Utils.md)
## Look At 2D
LookAt2D is a class that handles looking towards objects in 2D space, it also supports looking towards UI elements and looking towards the mouse.

To utilize this class, use the following functions:  

- **LookAtTransform**(target *Transform*, lookAt *Vector3*) returns *Quaternion*  
Returns rotation where *target* transform's x positive looks towards *lookAt* position.  
*lookAt* can also be a transform, in this case, the transform's position will be used.  
Example code:
```
transform.rotation = LookAt2D.LookAtTransform(transform, myVector3);
```

- **LookAtMouse**(target *Transform*, targetCamera *Camera*(optional)) returns *Quaternion*  
Returns rotation where *target* transform's x positive looks towards the mouse cursor.  
TargetCamera is the camera through which the mouse position in world space is determined, if left empty, Camera.main will be used.  
Example code:  
```
transform.rotation = LookAt2D.LookAtMouse(transform);
```

- **LookAtRectTransform**(target *Transform*, lookAt *RectTransform*, targetCamera* *Camera*(optional)) return *Quaternion*  
Returns rotation where *target* transform's x positive looks towards *lookAt* rect transform.  
TargetCamera is the camera through which the rect transform position in world space is determinded, if left empty, Camera.main will be used.  
Example code:  
```
transform.rotation = LookAt2D.LookAtRectTransform(transform, myRectTransform);
```