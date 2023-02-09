### [found in: Behaviours](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours.md)
## Object Spawner
The Object Spawner is used to spawn a prefab (or a selection of prefabs) at a list of positions.  
It has the following features: 

- **Prefabs** *OptionPicker\<GameObject\>*  
Settings for picking prefabs.

- **Spawn Points** *OptionPicker\<Transform\>*  
Settings for picking spawn points.

**Editor functions**
The following features are to speed up development and don't influence the functionality of the behaviour in any way.

- **Point Holder** *Transform*
Used for the auto compile featuer. The auto compile feature takes every direct child under this transform and adds them to the spawn points list.

- ***Refresh Spawn Points*** *Inspector Button*  
Clicking this will reset the spawn points list, after that, it takes every direct child under the Point Holder transform 
and adds them to the spawn points list.

It has the following functions:

- **SpawnObject**()  
Used to spawn an object using this behaviours settings.

- **SpawnObjectAtPrefabIndex**(index *int*)  
Used to spawn an object of the prefab at *index* using the baviors settings.

- **SpawnAtAllPoints**()  
Used to spawn an object at every spawn point using the behaviours settings.