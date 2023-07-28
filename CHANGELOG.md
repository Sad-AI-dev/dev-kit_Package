# Changelog  
All notable changes to this package will be documented in this file.  
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [] - Unreleased
This update includes a major documentation overhaul. All documentation has been moved to the gitHub's wiki page and has been reformatted.
Additionally, a lot of scripts depend on *FixedUpdate*, but still used *Time.deltaTime*, causing many issues.  
This has been addressed in this update by replacing these instances with *Time.fixedDeltaTime*.

### Added
New Scripts:

- Hide If Attribute
    - A new Util, which is a property that can be used to hide fields in the editor based on a conditional argument.
        - This has been a long time coming, and I'm very excited about its inclusion.

### Fixed
- Platformer 2D
    - no longer uses *Time.deltaTime*.

- Top Down Controller
    - no longer uses *Time.deltaTime*.

- Drone Controller
    - no longer uses *Time.deltaTime*.

- Platformer 3D Character Controller
    - no longer uses *Time.deltaTime*.

- Platformer 3D Rigidbody
    - no longer uses *Time.deltaTime*.
    - *OnMoveDirChanged* event not passing through new move direction.
    
- CameraShaker
    - Camera position not being reset after the camera shake.

- Mover
    - no longer uses *Time.deltaTime*.

### Changed
All Documentation has been moved to the gitHub's wiki page.
    - This also means that documentation is no longer included with the package files.

- Universal Input Receiver
    - The Universal Input Reciever no longer reads inputs when *Time.timeScale* is set to 0.
        - This is a simple solution to prevent functions from being called when a game is a paused.
        - This may become a setting.

### Removed
- Top Down Controller
    - Removed the *Set Position* option from *Move Mode*.
        - Directly setting the position causes countless issues and is not encouraged, so the option has been removed.

## [2.3.0] - Cleaning up Update - 09-02-2023
This update fixes various issues found during recent events.  
It also restructeres the documentation, rewrites the wave spawner and cleans up certain inspector windows.  
Overall, many long standing issues have been resolved, and the package received some nice polish.

### Added
New Scripts:

- LifeTime
    - a new behaviour that destroys or disables the gameobject after a set time.
        - this class is in a very basic state, I intend on expanding upon it at a later point.
    
- TimeSpanConverter
    - a util for converting float time values to formatted strings.

Additions to existing classes:

- AudioManager
    - *PlayOneShot* function.
        - use this function to prevent audio clipping.

### Changed
All documentation has been restructured to make use of subpages.
    - This hopefully makes the documentation more friendly to work with

- WaveSpawner
    - WaveSpawner recieved a complete rewrite.
        - It now makes use of some of the newer util scripts. It now also uses scriptable objects for determining wave content.

- UnityDictionary
    - Cleaned up appearance in inspector.
    - Internal dictionary is now private.
        - UnityDictionary can now directly be interfaced with.

- WeightedChance
    - Cleaned up appearance in inspector.

### Removed
- Interactable
    - DestroyInteractable function
        - functionality of this function is now automatically handled

### Fixed
Documentation link in package window linking to readme instead of documentation file.

- SliderHealthbar
    - Initial values being calculated at *Start*, causing it to occasionally not properly initialize.

- TransformHealthBar
    - Initial size being calculated at *Start*, causing it to occasionally not properly initialize.

- Interactable
    - Not handling decoupling on destroy / disable

- BehaviourPool & ObjectPool
    - New objects not being added to internal pool
    - Reactivated objects not being set to active

- OptionPicker
    - *GetOptionAtIndex* giving a indexOutOfRange exception.


## [2.2.0] - Anticipating Global Update - 21-01-2023
This update rewrites some of the older and messier classes, as well as adding more Util classes.  
Additionally, all scripts can now be found in the 'AddComponent' menu, isn't that neat?

### Added
All MonoBehaviour scripts can now be found under 'DevKit' in the AddComponent context menu.

New scripts:  

- Health Bar
    - An abstract class that handles a health bar.
        - Currently used by the healthManager.
        
- SliderHealthBar
    - Inherits from HealthBar. Shows health using a UI slider.
    
- TransformHealthBar
    - Inherits from Healthbar. Shows health by scaling a Transform.

- Behaviour Pool
    - A new Util class for reusing a pool of MonoBehaviours.
    - Variant: Object Pool
        - Almost identical, but manages a pool of GameObjects instead.
        
- Option Picker
    - Class that handles different ways of choosing an option from a list.

Additions to existing scripts:

- Object Spawner
    - *SpawnAtAllPoints* function.

- Interval Timer Manager
    - onTimerEnded *UnityEvent* to Interval Timer.

- HealthManager
    - healthBar variable
        - this goes along with the newly added healthBar classes.

- Weighted Chance
    - *Count* variable.

- Message Debugger
    - DebugMessage function variants to allow debugging values
        - currently supports the following types: 
            - MonoBehaviour
            - Object
            - int
            - float
            - double
            - Vector2
            - Vector3
            - bool
            - char
        
        - *DebugMessageGeneric* function

### Changed
- Readme file no longer includes documentation, it now links to the changelog and documentation file.

- Object Spawner is now based on Option Pickers.
    - This change resulted in a complete rewrite, make sure to check up on this class if you used it in your project!

- Weighted Chance *chances* list is now public, making it easier to interface with.

### Removed
Many redundant 'using' references in scripts.

- Object Spawner
    - Removed many variables for controlling prefab and spawn point selection.
        - This was replaced by the option picker classes.

- HealthManager
    - Removed all variables for controlling Health Bar.
        - These were delegated to the HealthBar classes.

### Fixed
- Interactor **TryInteract** function having a return value, making it impossible to call using Unity Events in the editor.
    - It now returns void.  
    The return value wasn't nescessary since it can be determined through other events.
    
- HealthManager
    - When *hitOnDeath* is set to *True*, *onDeath* triggers before *onHit*.
        - *onHit* now triggers first. This change in order makes more sense, since *onDeath* is likely to destroy the object.
    - Slightly improved performance.

### Known Issues
- Wave Spawner is in a outdated state and needs a rewrite. this will be addressed in the next update.


## [2.1.1] - hotfix 1 - 15-11-2022
Fixes a small issue found with the new stop functionality from the Cost Based Activator behavior.

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

### Known Issues:
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