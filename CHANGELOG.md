# Changelog  
All notable changes to this package will be documented in this file.  
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [unreleased]



## [1.2.0] - 06-10-2022
This minor update adds some more ambitious features that I personally wanted to add.  
It also includes a fix that makes Unity Dictionary a lot more viable to work with.

### Added
- color gradient support for slider health bar in Health Manager Script.

### Changed
- SimpleInventory system now uses Unity Dictionary instead of lists.
    - This change greatly increases performance.

### Fixed
- Unity Dictionary not displaying modified values in inspector.


## [1.1.0] - 06-10-2022
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


## [1.0.0] - 04-10-2022
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