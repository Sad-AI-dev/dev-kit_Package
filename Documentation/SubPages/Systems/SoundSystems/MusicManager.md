### [found in: Sound Systems](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/SoundSystems/SoundSystems.md)
## Music Manager
The Music Manager is a *singleton* system for playing music. This system uses *DontDestroyOnLoad* and can be placed anywhere in the hierarchy.  
To use the system through script, use the following pattern:
```
MusicManager myMusicManager = MusicManager.instance;
```
It should be noted that this only works so long there is a Music Manager script attached to an object in the current scene.  
It has the following features:

- **Tracks** *UnityDictionary\<string, [Sound](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/SoundSystems/Sound.md)\>*  
Dictionary that stores settings for every music track in this system. To Add a new track to the system, add a new entry to the dictionary.  
Because this is a dictionary, each *Key* must be unique. Each *Key* is associated with a *[Sound](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/SoundSystems/Sound.md)*.  
    
- **Mute Time** *float*  
Determines the time it takes for the currently playing track to be muted when switching tracks.

- **Transition Time** *float*  
Determines the time it takes for the new track to reach the desired volume when switching tracks.
    
It has the following functions:

- **SwitchTrack**(name *string*)  
Looks for a music track in the *Tracks* dictionary with a key that matches *name*. 
If one is found, the current music track will be muted, the desired track will start playing and is unmuted.  
If nothing is found, an error will be thrown.