### [found in: Behaviours](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours.md)
## Path Follower
The path follower makes the gameobject that this behaviour is attached to follow a predetermined path.  
It has the following features:

- **Move Speed** *float*  
Determines how fast the object moves along the path.

- **Step Mode** *enum*  
Dictates how many steps are taken along the path before automatically stopping 
when *Startmove* is Invoked, has the following options:
    - *Step*: the object stops after reaching the next point along the path.
    - *Cycle*: the object stops after reaching the final point along the path.
    - *Continuous*: the object never stops unless *StopMove* is Invoked.
    
- **Loop Mode** *enum*
Dictates how the object behaves after reaching the final point along the path, has the following options:
    - *Reset*: the object is teleported back to the first point.
    - *Loop*: the object travels back to the first point.
    - *Bounce*: the object travels back through the path in reverse order.
    
- **Rotate Speed** *float*  
Determines how fast the object rotates to the target rotation.

- **Rotate Mode** *enum*  
Dictates how rotation is handles while following the path, has the following options:
    - *None*: the object will not be rotated.
    - *Look_ahead*: the object will look towards the next point in the path.
    - *Use_point_rotation*: the object will look towards the rotation of the next point in the path.
    
- **Move on Start** *bool*  
When set to true, the object will start following the path when *Start* is Invoked. When false, this does nothing.

- **Path** *List\<Path Point\>*  
A list that holds the points that make up the path that the object will follow. 
Each point in the path has the following elements:
    - **Point** *Transform*  
    Defines the point along the path.
    - **Delay** *float*  
    Amount of time to wait before being able to move on to the next point.

**Editor functions**
The following features are to speed up development and don't influence the functionality of the behaviour in any way.

- **Path Holder** *Transform*
Used for the auto compile feature. The auto compile feature takes every direct child under this transform and adds them to the path list.

- ***Refresh Path Points*** *Inspector Button*  
Clicking this will reset the spawn points list, after that, it takes every direct child under the Path Holder transform 
and adds them to the path list.

It has the following functions:

- **StartMove**()  
Used to start moving along the path.

- **StopMove**()  
Used to stop moving along the path.