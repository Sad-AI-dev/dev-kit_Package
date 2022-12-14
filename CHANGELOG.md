# Changelog  
All notable changes to this package will be documented in this file.  
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [2.1.1] - hotfix 1 - 15-11-2022
Fixes a small issue found witht he new stop functionality from the Cost Based Activator behavior.

### Fixed
Cost Based Activator
- issue where budget would be gained before stopping.

## [2.1.0] - Spawning Specifics Update - 15-11-2022
While developing a game using this package, I found some features I needed that weren't available.  
To fix this, I added some features to the Object Spawner and the Cost Based Activator.

### Added
- **SpawnObjectAtPrefabIndex** function to Object Spawner behavior.
- **Set** option to *PrefabSelectMode* to Object Spawner behavior.
    - this option is meant to be used when spawning using *SpawnObjectAtPrefabIndex* function.
    
- **Stop** function to the Cost Based Activator behavior.

### Fixed
- small inefficiency with some OnValidate functions.

Known Issues:
- Wave Spawner 'consumes' it's settings, making it hard / impossible to respawn past waves.
- Scripts do not show up in the 'Add Component' menu

## [2.0.0] - New Frontiers Update - 13-11-2022
This update adds some completely new behaviors that I have been meaning to add.  
It also adds a few new features to existing classes, and some important fixes.  
As an important note: All classes are now in the DevKit namespace.

### Added
New scripts:

- Cost Based Activator behavior
    - A behavior for procedural budget based option activation.
    - Includes rampup and save features.
        - I've made entire games around similar systems to this, so I'm very happy to create a definitive and expanded version of those systems.
        
- Interval Timer Manager
    - A behavior for managing interval timers.
        - This was a behavior suggested to me. I'm looking forward to the ways this behavior can be used in projects.
        
- Camera Shaker behavior
    - A  behavior for simulating camera shake.
        - The current version is very bare-bones, so I hope to add more features to it in the future.

- Texture Scroller
    - A behavior that scrolls a texture.
        - It's pretty simple, but I like using this behavior for spicing up static UI screens.

Additions to existing scripts:

- Read Mouse Scroll Wheel *bool* to *Axis Input* in *Universal Input Receiver* behavior
    - setting this option to true allows for reading the scrollwheel as input.

- Whitelist Tags *List\<string\>* to *Object Detector* behavior.
    - This allows tighter control on which objects should be detected.

- moveSpeed *float* to *Mover* Behavior
    - this seperates the move direction from the move speed, making it easier to be changed by an external source.

- Priority *int* to *Sound* class
    - allows setting of priority of each sound.
- Bypass settings to *Sound* class
    - additional settings for bypassing effects.
    
### Changed
- All scripts included in the package are now under the 'DevKit' namespace

- moveDirection on the *Mover* Behavior is now normalized on start.
    - this is to ensure move direction and move speed are seperated.
    
- TryInteract() on the *Interactor* class will now return a bool.
    - returns true is an *Interactable* is found, returns false if not.
    
- renamed *Ignore Tags* to *Blacklist Tags*

### Fixed
- Missing and inconsistent documentation on functions.

- UIPathFollower StartMove function being private.
    - It is now public.
    
- Issue where *Sound* class default values were not set.


## [1.3.0] - Going Public Update - 01-11-2022
This update aims to make the package easier to work with by turning a lot of variables public instead of private.

### Added
- Output *Audio Mixer Group* to *Sound* class
    - this should allow for better mixing options

### Changed
- Most variables changed from private to public.
    - This is a leftover result of my personal development style. In order to make the package as a whole easier to work with, I wanted to make as much as possible public. A few variables are still private, because they shouldn't be changed during runtime.

### Removed
- On Interact Void event on the Interactable
    - During development, the *Interactor* parameter was added to the On Interact event. The On Interact Void event is a relic of development that has no reason to exist.
    
### Fixed
- Interactor debug log
    - Left over from development, no reason to exist


## [1.2.0] - Selfish Colors Update - 06-10-2022
This minor update adds some more ambitious features that I personally wanted to add.  
It also includes a fix that makes Unity Dictionary a lot more viable to work with.

### Added
- color gradient support for slider health bar in Health Manager Script.

### Changed
- SimpleInventory system now uses Unity Dictionary instead of lists.
    - This change greatly increases performance.

### Fixed
- Unity Dictionary not displaying modified values in inspector.


## [1.1.0] - Jammin' Update - 06-10-2022
This update adds a veriaty of requested features that was gathered as feedback.  
It also fixes some issues that were found during testing.

### Added
- ObjectDetector class
    - A behavior that can be used to detect objects using tags.
    
- OnChangeMoveDir event to the TopDownController, Platformer3D_Rigidbody and Platformer3D_CharacterController scripts.
- OnChangeHorMoveDir and OnChangeVerMoveDir events to the DroneController script.

- OnButtonHeld event to Button Inputs in the UniversalInputReciever script.

- Repeat Final Wave feature to Wave Spawner.

- Max health field to Health Manager.
- On Hit and On Heal events on Health Manager now pass the amount healed / damage taken as a float parameter.

### Changed
- Mover now uses Rigidbody to move.
    - The Mover class was always intended to be used for objects like bullets, so it should be able to detect collision.
    
### Removed
- GroundDetector 2D, GroundDetector 3D
    - These scripts have been replaced by the object detector behavior.

### Fixed
- Drone controller moving faster after building (switched from update to fixedUpdate).


## [1.0.1] - 05-10-2022
this patch fixes some technical settings that resulted in errors while building projects.

### Fixed
- Editor assembly definition file throwing errors on project build


## [1.0.0] - Launch Update - 04-10-2022
This is the official release of the dev kit.

### Added
- All mandatory package files
- Initial selection of scripts/systems:
    - Controllers
        - Universal Input Reciever
        - Platformer 2D
        - Top Down Controller
        - Platformer 3D Rigidbody
        - Platformer 3D Character Controller
        - Drone Controller
        - Ground Detector 2D
        - Ground Detector 3D
    - Behaviors
        - Object Spawner
        - Wave Spawner
        - Path Follower
        - Mover
        - Rotator
        - UI Path Follower
        - UI Toggle Mover
        - UI Fader
    - Systems
        - Recipe System
        - Interaction System
        - Dialogue System
        - Simple Inventory
        - Health Manager
        - Sound Manager
        - Music Manager
    - Utils
        - Look At 2D
        - Weighted Chance
        - Unity Dictionary
        - Collection Utils
        - Message Debugger