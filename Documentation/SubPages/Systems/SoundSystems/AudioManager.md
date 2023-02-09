### [found in: Sound Systems](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/SoundSystems/SoundSystems.md)
## Audio Manager
The Audio Manager is a *singleton* system for playing sounds.  
To use the system through script, use the following pattern:  
```
AudioManager myAudioManager = AudioManager.instance;
```
It should be noted that this only works so long there is a Audio Manager script attached to an object in the current scene.  
It has the following features:

- **Sounds** *UnityDictionary\<string, [Sound](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/SoundSystems/Sound.md)\>*  
Dictionary that stores settings for every sound effect in this system. To Add a new sound to the system, add a new entry to the dictionary.  
Because this is a dictionary, each *Key* must be unique. Each *Key* is associated with a *[Sound](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/SoundSystems/Sound.md)*.  
    
It has the following functions:

- **Play**(name *string*)
Looks for a sound in the *Sounds* dictionary with a key that matches *name*, if one is found, it is played.  
If no sound is found, an error will be thrown.

- **PlayOneShot**(name *string*)
Looks for a sound in the *Sounds* dictionary with a key that matches *name*, if one is found, it is played as a oneshot.  
If no sound is found, an error will be thrown.  
Use this function to prevent audio clipping.