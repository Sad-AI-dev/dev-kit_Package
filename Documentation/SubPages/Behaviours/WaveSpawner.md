### [found in: Behaviours](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours.md)
## Wave Spawner 
The Wave Spawner is a behaviour that spawns predetermined sets of prefabs in set waves.  
Data for each wave is stored using [Wave Content SO](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours/WaveContentSO.md).  
It has the following features:

- **Spawn On Start** *bool*  
When set to *true*, SpawnNextWave will be called on start. When set to *false*, does nothing.

- **Activate Mode** *enum*  
Dictates how waves are started, has the following options:
    - *Manual*: each wave must be manually started using the *StartWave* function.
    - *Delay*: the next wave will automatically be started after a configurable delay.

- **On Wave End** *UnityEvent*  
This event invokes when a wave finishes spawning.

- **Waves** *List\<[WaveContentSO](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours/WaveContentSO.md)\>*  
Stores the information for each wave.

- **Spawn Points** *OptionPicker\<Transform\>*  
Stores settings for where objects should be spawned.


**Editor functions**
The following features are to speed up development and don't influence the functionality of the behaviour in any way.

- **Point Holder** *Transform*
Used for the auto compile featuer. The auto compile feature takes every direct child under this transform and adds them to the spawn points list.

- ***Refresh Spawn Points*** *Inspector Button*  
Clicking this will reset the spawn points list, after that, it takes every direct child under the Point Holder transform 
and adds them to the spawn points list.

It has the following functions:

- **SpawnNextWave**()  
Used to spawn the next wave.