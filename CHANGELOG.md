# Changelog  
All notable changes to this package will be documented in this file.  
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [1.0.0] - 06-10-2022
### Added
- ObjectDetector class
    - A behavior that can be used to detect object using tags.
    
- OnChangeMoveDir event to the TopDownController, Platformer3D_Rigidbody and Platformer3D_CharacterController scripts.
- OnChangeHorMoveDir and OnChangeVerMoveDir events to the DroneController script.

- OnButtonHeld event to Button Inputs in the UniversalInputReciever script.

- Repeat Final Wave feature to Wave Spawner.

- Max health field to Health Manager.
- On Hit and On Heal events on Health Manager now pass the amount healed / damage taken as a float parameter.

### Removed
- GroundDetector 2D, GroundDetector 3D
    - These scripts have been replaced by the object detector behavior.

### Changed
- Mover now uses Rigidbody to move.
    - The Mover class was always intended to be used for objects like bullets, so it should be able to detect collision.

### Fixed
- Drone controller moving faster after building (switched from update to fixedUpdate).


## [1.0.1] - 05-10-2022
### Fixed
- Editor assembly definition file throwing errors on project build


## [1.0.0] - 04-10-2022
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