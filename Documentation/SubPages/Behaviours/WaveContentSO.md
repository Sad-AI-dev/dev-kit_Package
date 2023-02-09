### [found in: Wave Spawner](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours/WaveSpawner.md)
## Wave Content SO
This scriptable object stores the information for an individual wave.  
Objects are spawned in the same order as the scriptable object.  
It has the following features:

- **Wave Content** *List\<ObjectGroup\>*  
The list storing all information for the wave.  
Each ObjectGroup has the following features:
    - **Prefab** *GameObject*  
    A prefab of the object that should be spawned.
    - **Count** *int*  
    The amount of this prefab to be spawned.
    - **Next Object Delay** *float*  
    The amount of time the behaviour waits between spawning each individual object.
    - **Next Group Delay** *float*  
    The amount of time the behaviour waits before it starts spawning the next element in the list.