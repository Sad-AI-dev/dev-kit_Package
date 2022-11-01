# dev-kit Library
A library for unity containing reusable scripts, aimed to speed up prototyping.  
The library contains scripts in 4 categories: Controllers, Behaviors, Systems, and Utils.

Each category has the following characteristics:
- Controllers
    - Controllers contains scripts that form the basics for player movement, as well as input detection.
- Behaviors
    - Behaviors contains simple straight forward components.
- Systems
    - Systems contains groups of components that work together as a complex system.
- Utils
    - Utils are meant to help smooth over development, not change the game experience.


# Documentation
This is the documentation for the dev-kit package. Documentation is split up in 4 categories: Controllers, Behaviors, Systems and Utils.  
This matches the file structure in the package.

# ==Controllers==
## Universal Input Reciever
allows for setting up of inputs through the editor.  
It supports keycode inputs and codes from the input manager.

The input reciever contains 3 seperate input types:
1. **Button Input**
    - Button inputs are intended for single button inputs, and has the following features:
        - **Name** *string*  
        Used for orginazation in the editor, has no technical purpose.
        - **On Button Down**  *UnityEvent*  
        Invoked when a tracked input is pressed down.
        - **On Button Held** *UnityEvent*  
        Invoked when a tracked input is held down.
        - **On Button Up** *UnityEvent*  
        Invoked when a tracked input is released.  
        
        - **Codes** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for inputs.  
        
        - **Button Codes** *List\<string\>*  
        List of strings, these are input manager codes that are tracked for inputs.  
        
2. **Axis Input**
    - Axis inputs are intended for 2 seperate inputs that act as a singular float axis from -1 to 1. It has the following features:
        - **Name** *string*  
        Used for orginazation in the editor, has no technical purpose.
        - **Output** *UnityEvent\<float\>*  
        Invoked every frame, outputs current axis value.  
        
        - **Pos Input** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for positive inputs along the axis.
        - **Neg Input** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for negative inputs along the axis.  
        
        - **Axis Codes** *List\<string\>*  
        List of strings, these are input manager codes that are tracked for inputs.  
        
3. **Directional Input**
    - Directional inputs are intended for 4 seperate inputs that act as a singular Vector2 from (-1, -1) to (1, 1). It has the following features:
        - **Name** *string*  
        Used for orginazation in the editor, has no technical purpose.
        - **Output** *UnityEvent\<Vector2\>*  
        Invoked every frame, outputs current directional value.  
        
        - **X Pos Input** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for positive inputs along the X axis.
        - **X Neg Input** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for negative inputs along the X axis.
        - **Y Pos Input** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for positive inputs along the Y axis.
        - **Y Neg Input** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for negative inputs along the Y axis.  
        
        - **X axis Codes** *List\<string\>*  
        List of strings, these are input manager codes that are tracked for inputs along the X axis.
        - **Y axis Codes** *List\<string\>*  
        List of strings, these are input manager codes that are tracked for inputs along the Y axis.  

**A quick note on input reading**  
Due to the nature of tracking multiple inputs at a time, some compromises were made:  
For button inputs, *on button down* and *on button up* can both be Invoked once per frame.  
For axis inputs and directional inputs, when multiple changes are detected on an axis, the input furthest from neutral (0) will be used.

## Platformer 2D 
A controller with simple 2D platforming controls, use the *SetMoveDir* function for movement 
and the *StartJump* and *EndJump* functions for jumping.  
The controller has the following features:

- **Top Speed** *float*  
Dictates the max velocity.
- **Acceleration** *float*  
Dictates how fast the controller reached max velocity.
- **Deceleration** *float*  
Dictates how fast the controller slows down.
- **Facing Left** *bool*  
Determines which way the controller is facing, can be used to set the starting facing direction.  
Use *IsFacingLeft* to check if controller is facing left, cannot be set.

- **Jump Height** *float*  
Dictates how high the controller jumps.
- **Rise Grav** *float*  
Sets the gravity while rising during a jump. This gravity will be used until the jump button is released or the jump reached the peak of its arc.
- **Fall Grav** *float*  
Sets the gravity while falling during a jump.  

- **Jump Buffer Time** *float*  
Dictates the size of the jump input buffer. Jump buffer is used to allow the controller to retroactively jump if they input jump a bit before landing.
- **Coyote Time** *float*  
Dictates the length of coyote time. Coyote time allows the controller to jump just after falling off a platform.  

- **Ground Detector** *GroundDetector2D*  
A reference to the ground detector that should be used.

## Top Down Controller
A controller with simple top down 2D controls, use *SetMoveDir* for movement.  
The controller has the following features:

- **Top Speed** *float*  
Dictates the max velocity.
- **Acceleration** *float*  
Dictates how fast the controller reached top speed.

- **On Change Move Dir** *UnityEvent\<Vector2\>*  
Event that is invoked when the move direction chances, passes Vector2 move direction as a parameter.

- **Mode** *enum*  
Determines the way movement is handled. Has 3 modes:
    - *Set Position*: Directly sets the position of the controller.
    - *Set Velocity*: Directly sets the velocity of the rigidbody2D attached to the object.
    - *Use Force*: Uses the AddForce function on the rigidbody2D attached to the object.

## Platformer 3D Rigidbody
A controller for 3D platforming using the Rigidbody component, use the *SetMoveDir* and *Jump* functions for movement and jumping respectively.  
The controller has the following features:

- **Top Speed** *float*  
Dictates the top speed.
- **Acceleration** *float*  
Dictates how fast the controller reached max velocity.
- **Deceleration** *float*  
Dictates how fast the controller slows down.
- **On Change Move Dir** *UnityEvent\<Vector2\>*  
Event that is invoked when the move direction chances, passes Vector2 move direction as a parameter.  

- **Jump Height** *float*  
Dictates how high the controller jumps.  

- **Jump Buffer Time** *float*  
Dictates the size of the jump input buffer. Jump buffer is used to allow the controller to retroactively jump if they input jump a bit before landing.
- **Coyote Time** *float*  
Dictates the length of coyote time. Coyote time allows the controller to jump just after falling off a platform.  

- **Ground Detector** *GroundDetector3D*  
 reference to the ground detector that should be used.

## Platformer 3D Character Controller
A controller for 3D platforming using the Character Controller component, 
use the *SetMoveDir* and *Jump* functions for movement and jumping respectively.  
The controller has the following features:

- **Top Speed** *float*  
Dictates the top speed.
- **Acceleration** *float*  
Dictates how fast the controller reached max velocity.
- **Deceleration** *float*  
Dictates how fast the controller slows down.
- **On Change Move Dir** *UnityEvent\<Vector2\>*  
Event that is invoked when the move direction chances, passes Vector2 move direction as a parameter.  

- **Jump Height** *float*  
Dictates how high the controller jumps.  
- **Gravity** *float*  
Dictates the gravity on the controller.

- **Jump Buffer Time** *float*  
Dictates the size of the jump input buffer. Jump buffer is used to allow the controller to retroactively jump if they input jump a bit before landing.
- **Coyote Time** *float*  
Dictates the length of coyote time. Coyote time allows the controller to jump just after falling off a platform.  

## Drone Controller
A controller for 3 axis 3D movement, use the *SetVerMoveDir* function for movement along the y axis, 
and the *SetHorMoveDir* function for all other movement.  
The controller has the following features:

- **Hor Top Speed** *float*  
Dictates the top speed on the horizontal axis.
- **Hor Acceleration** *float*  
Dictates how fast the controller reached max velocity on the horizontal axis.
- **Hor Deceleration** *float*  
Dictates how fast the controller slows down on the horizontal axis.
- **On Change Hor Move Dir** *UnityEvent\<Vector2\>*  
Event that is invoked when the horizontal move direction changes, passes *Vector2* move direction as a parameter.  

- **Ver Top Speed** *float*  
Dictates the top speed on the vertical axis.
- **Ver Acceleration** *float*  
Dictates how fast the controller reached max velocity on the vertical axis.
- **Ver Deceleration** *float*  
Dictates how fast the controller slows down on the vertical axis.
- **On Change Ver Move Dir** *UnityEvent\<Vector2\>*  
Event that is invoked when the vertical move direction changes, passes *float* move direction as a parameter 

# ==Behaviors==
## Object Detector
Used to detect if something is overlapping with an attached (2D) trigger collider, has the following features:

- **On Detect First Object** *UnityEvent*  
Event that is Invoked when the first object is found.
- **On Detect Object** *UnityEvent*  
Event that is Invoked every time a object is detected.
- **On Leave Last Object** *UnityEvent*  
Event that is Invoked when last object goes out of range.  

- **Ignore Tags** *List\<string\>*  
List of tags that are ignored when an object is detected.

**A quick note on use with Controllers**  
Controllers always setup event listeners on their own for the object detectors. The Unity Events are purely for custom behaviour.

## Object Spawner
The Object Spawner is used to spawn a prefab (or a selection of prefabs) at a list of positions. 
Use the *SpawnObject* function to activate the behavior.  
The behavior has the following features: 

- **Spawn Mode** *enum*  
Dictates how objects are spawned, has the following options:
    - *Wave*: spawns a prefab at every point in the spawn points list.
    - *Random*: spawns a single prefab at a randomly selected spawn point.
    - *Round_robin*: spawns a single prefab at a single spawn point. The spawn point is chosen in order, starting at index 0 and resetting after the last spawn point in the list is chosen.
    
- **Prefab Select Mode** *enum*  
Decides how the behavior decides which prefab to spawn, has the following options:  
    - *Random*: The behavior picks a random prefab to spawn.
    - *Round_robin* The behavior picks a prefab in order starting at index 0 and resetting after the last prefab in the list has been chosen.

- **Prefabs** *List\<GameObject\>*  
A list that holds the prefabs that are referenced when spawning an object.

- **Spawn Points** *List\<Transform\>*  
A list that holds all the possible spawn locations that an object is allowed to be spawned at.

**Editor functions**
The following features are to speed up development and don't influence the functionality of the behavior in any way.

- **Point Holder** *Transform*
Used for the auto compile featuer. The auto compile feature takes every direct child under this transform and adds them to the spawn points list.

- ***Refresh Spawn Points*** *Inspector Button*  
Clicking this will reset the spawn points list, after that, it takes every direct child under the Point Holder transform 
and adds them to the spawn points list.

## Wave Spawner
The Wave Spawner is used to spawn a predetermined set of prefabs in waves at a list of positions.
Use the *SpawnWave* function to spawn the next wave.
The behavior has the following features:

- **Activation Mode** *enum*  
Dictates how waves are started, has the following options:
    - *Manual*: each wave must be manually started using the *StartWave* function.
    - *Delay*: the next wave will automatically be started after a configurable delay.
    
- **Spawn on Start** *bool*  
If set to true, automatically spawns the first wave when *Start* is Invoked, otherwise, does nothing.
- **Repeat Final Wave** *bool*  
If set to true, final wave can be spawned multiple times, otherwise, does nothing.  

- **Spawn Point Selection Mode** *enum*  
Dictates which spawnpoint is chosen when spawning a prefab, has the following options:
    - *Random*: a random spawn point is chosen.
    - *Round_robin*: the spawn point is chosen in order, starting at index 0 and 
    resetting after the last spawn point in the list has been chosen.

- **Object Selection Mode** *enum*  
Dictates the order prefabs within a wave are spawned, has the following options:
    - *In_order*: prefabs are spawned in the order of the content list.
    - *Random*: prefabs are spawned in a random order.
    
- **Waves** *List\<WaveData\>*  
Stores the information for each wave. Each wave has the following information:
    - **Name** *string*  
    Used for orginazation in the editor, has no technical purpose.
    - **Content** *List\<PrefabCount\>*  
    Defines the content of the wave, each element has the following features:
        - **Prefab** *GameObject*  
        The prefab to be spawned.
        - **Count** *int*  
        The amount of times the prefab should be spawned in this wave.
        - **Spawn Delay** *float*  
        Determines the delay before spawning the next prefab.
        - **Wave Delay** *float*
        Only used when *activation mode* is set to *Delay*. 
        Determines the delay before spawning the next wave.
        
- **Spawn Points** *List\<Transform\>*  
A list that holds all the possible spawn locations that a prefab is allowed to be spawned at.

**Editor functions**
The following features are to speed up development and don't influence the functionality of the behavior in any way.

- **Point Holder** *Transform*
Used for the auto compile featuer. The auto compile feature takes every direct child under this transform and adds them to the spawn points list.

- ***Refresh Spawn Points*** *Inspector Button*  
Clicking this will reset the spawn points list, after that, it takes every direct child under the Point Holder transform 
and adds them to the spawn points list.

## Path Follower
The path follower makes the gameobject that this behavior is attached to follow a predetermined path. 
Use the *StartMove* to start moving along the path and *StopMove* to stop moving along the path.  
The path follower has the following features:

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
The following features are to speed up development and don't influence the functionality of the behavior in any way.

- **Path Holder** *Transform*
Used for the auto compile feature. The auto compile feature takes every direct child under this transform and adds them to the path list.

- ***Refresh Path Points*** *Inspector Button*  
Clicking this will reset the spawn points list, after that, it takes every direct child under the Path Holder transform 
and adds them to the path list.

## Mover
The mover moves the gameObject the behavior is attached to in a predifined local direction. 
Use the *StartMove* and *StopMove* functions to start and end moving respectively.  
It has the following features:

- **Move Direction** *Vector3*  
Determines (in local space) which direction the object goes and how fast it travels.

- **Move on Start** *bool*  
If set to true, start moving when *Start* is Invoked. When set to false, the object only starts moving after *StartMove* is Invoked.

## Rotator
The rotator rotates the gameObject the behavior is attached to in a predifined local direction. 
Use the *StartRotate* and *StopRotate* functions to start and end rotating respectively.  
It has the following features:

- **Rotate Direction** *Vector3*  
Determines (in local space) which direction the object rotates in and how fast it rotates.

- **Rotate on Start** *bool*  
If set the true, start rotating when *Start* is Invoked. When set the false, the object only starts rotating after *StartRotate* is Invoked.

## UI Path Follower
The UI Path Follower moves the rect transform along a predefined list of rect transforms. 
Use the *StartMove* and *EndMove* functions to start and stop moving respectively.  
It has the following features:

- **Move Speed** *float*  
Determines how fast the rect transform travels along the path.

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
    
- **Move on Start** *bool*  
When set to true, the object will start following the path when *Start* is Invoked. When false, this does nothing.

- **Path** *List\<Path Point\>*  
A list that holds the points that make up the path that the object will follow. 
Each point in the path has the following elements:
    - **Transform** *RectTransform*  
    Defines the point along the path.
    - **Delay** *float*  
    Amount of time to wait before being able to move on to the next point.

**Editor functions**
The following features are to speed up development and don't influence the functionality of the behavior in any way.

- **Path Holder** *RectTransform*
Used for the auto compile feature. The auto compile feature takes every direct child under this transform and adds them to the path list.

- ***Refresh Path Points*** *Inspector Button*  
Clicking this will reset the spawn points list, after that, it takes every direct child under the Path Holder transform 
and adds them to the path list.

## UI Toggle Mover
Used to move the rect transform that the toggle mover is attached to between two defined positions, 
the position of the rect transform is considered the start position on *Start*. 
Use the *StartMove* function to move from one point to the other.  
It has the following features:

- **End Position** *RectTransform*  
Destination to travel towards.

- **Move Mode** *enum*  
Dictates how the rect transform travels to the target destination, has the following options:
    - *Linear*: Moves towards the target destination linearly.
    - *Lerp*: Moves towards the target smoothly using linear interpolation.
    
- **Move Speed** *float*  
Determines how fast the rect transform travels.

- **Move on Start** *bool*  
When set to true, the object will start moving when *Start* is Invoked. When false, this does nothing.

## UI Fader
Used to fade a UI Canvas Group. Use the *StartFade* and *StopFade* functions to start or stop fading the canvas group.  
It has the following features:

- **Target Group** *CanvasGroup*  
The canvas group that should be faded.

- **Fade Mode** *enum*  
Dictates how the fader behaves when *StartFade* is Invoked, has the folling options:
    - *Single*: fades in or fades out, based on current state.
    - *Cycle*: fades in and fades out, order depends on start state.
    - *Blink*: blinks for a set time.
    - *Blink_continuous*: blinks until *StopFade* is Invoked.
    
- **Fade on Start** *bool*  
When set to true, the canvas group will start fading when *Start* is Invoked. When false, this does nothing.

- **Fade Time** *float*  
Dictates the time it takes to fully fade in or out.

- **Faded in Delay** *float*  
Delay between end of fade-in and start of fade-out.

- **Faded out Delay** *float*  
Delay between end of fade-out and start of fade-in.

- **Blink Time** *float*
Only used when *Fade Mode* is set to *Blink*. Determines for how long the Canvas Group fades.

# ==Systems==
## Recipe System
The recipe system is a system that takes a number of imputs, compares it to programmed recipes and, if possible, returns a single output. 
Use the *TryRecipe* function to see if a number of imputs is a recipe and returns an output.  
The Recipe System includes the following scripts:

### Recipe Processor
The recipe processor holds recipes, use the *TryRecipe* to get a result output if the recipe is valid. 
The recipe processor is not a MonoBehavior, to use it, add it as a variable to a different MonoBehavior.  
It has the following features:

- **Recipes** *List\<RecipeSO\>*  
The list of recipes referenced by the recipe processor.

### Recipe SO
The Recipe SO holds the information that makes up a recipe. 
The recipe processer uses these to process inputs and return an output if inputs are valid.  
To use the recipe SO, create a class that inherits from the recipe SO with the desired variable types, like this:
```
[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Recipe")]
public class MyRecipeSO : RecipeSO<string, string> {

}
```
The Recipe SO has the following features:

- **Inputs** *List\<Input\>*  
The type is determined by the inheritor class. Stores the inputs in the recipe that result in the output. 
When *TryRecipe* is Invoked with these inputs, output will be returned.

- **Perfect Match** *bool*  
If set to true, the order in which the inputs are submitted when *TryRecipe* is Invoked, needs to perfectly match the inputs list on the recipe. 
When set to false, the order of the inputs doesn't matter.

- **Ouput** *Output*  
The type is determined by the inheritor class. Output gets returned when *TryRecipe* is Invoked and the input is valid.

## Interaction System
The interaction system is a system that takes a Interact input and interacts with the closest interactable if possible. 
To use the system, attach the interactor script to the object that recieves inputs to interact, 
and call the *TryInteract* function on the Interactor. Attach the Interactable script on the item to be interacted with.  
The system has the following scripts:

### Interactor
The interactor script can be attached to the object in order to allow it to interact. 
Use the *TryInteract* function to interact with nearby interactables.  
It has the following features:

- **On Can Interact** *UnityEvent*  
Event is Invoked when the interactor encounters an interactable and no other interactables are in range.

- **On Stop Can Intreact** *UnityEvent*  
Event is Invoked when the interactor moves out of range from an interactable and no other interactables are in range.

### Interactable
The Interactable script can be attached to an object to allow it to be interacted with. 
If the interactable needs the be destroyed, use the *DestroyInteractable* function. 
In order to function, the interactable needs a trigger collider to detect interactors.  
It has the following features:

- **On Interact** *UnityEvent\<Interactor\>*  
Identical to On Interact Void, but passes the interactor that interacted with the object as a parameter.

## Dialogue System
The Dialogue System allows for simple branching dialogue scripted using scriptable objects. 
It uses Text Mesh Pro UI elements to display dialogue, and requires a butten template prefab for response buttons. 
Use the Dialogue Activator and the *StartDialogue* function to start a dialogue.

For this system to work as intended, a fairly specific setup of UI elements is required, 
more details can be found under the features section of this script and the response handler script.

The System has the Following scripts:

### Dialogue UI
The Dialogue UI is the cornerstone of the dialogue system, it handles the displaying of dialogue data to the UI and showing responses.  
It has the following features:

- **Dialogue Box** *GameObject*  
The GameObject that holds everything related to displaying dialogue. This object is disabled / enabled based on if dialogue is active.

- **Dialogue Label** *TMP_Text*  
The text element that displays the dialogue content. This element should be a child of the dialogue box.  
Small note, the system does not check if dialogue from a dialogueSO fits in this label. 
It is recommended to either automatically scale text using the *Auto Size* feature from TMP_Text or handle overflow in some other way.

- **Name Label** *TMP_Text*  
The text element that displays the name of who is speaking. This element should be a child of the dialogue box.  
Small note, the system does not check is a name will fit, so use of the *Auto Size* feature from TMP_Text is recommended.

- **On Dialogue Start** *UnityEvent*  
Unity Event that is Invoked when a new dialogue is started. Does *not* trigger when picking a response results in more dialogue.

- **On Dialogue End** *UnityEvent*  
Unity Event that is Invoked when dialogue ends.

### Response Handler
The response handler script handles the displaying of responses and triggering response events.  
It has the following features:

- **Response Box** *Rect Transform*  
Rect Transform that holds everything related to response UI elements. Height should be set to 0, as it will automatically be scaled when responses are displayed.

- **Response Container** *Rect Transform*  
Rect Transform that holds the response buttons when they are created.  
This element should be a child of the response box. The rect transform should also be set to *stretch* in both directionts.  
Additionaly, this rect transform should have the *Vertical Layout Group* component, which has the following settings:
    - *Child Alignment* set to *Middle Right*. (is optional)
    - For *Control Child Size*, *Width* set to *True* and *Height* set to *False*.
    - *Use Child Scale* all set to *False*
    - *Child Force Expand* all set to *True*
    - The *Spacing* should be set to 0, spacing can be created through the *Button Template* prefab.
    
- **Button Template** *Rect Transform*  
Rect Transform that will be used as a template for creating the response buttons. Must be a prefab to work as intended.

### Typewriter Effect
The typewriter effect script handles the display effect, which displays each character in order, for the dialogue text.  
It has the following features:

- **Delay** *float*  
The delay in seconds between each character being displayed.

- **Punctuations** *List\<Punctuation\>*  
The punctuations list controls additionals delays for specific characters.  
It has the following elements:
    - **Punctuations** *List\<char\>*  
    Holds the characters that should trigger the additional delay.
    - **Wait Time** *float*  
    The additional time that should be waited when the punctuation is encountered.

### Dialogue Activator
The Dialogue Activator is used for starting a dialogue sequence. 
Use the *StartDialogue* to start a dialogue, the function takes a Dialogue UI as a parameter.  
It has the following features:

- **Data** *DialogueData*  
When *StartDialogue* is Invoked, this dialogue data will be used as a starting point for the dialogue.

### Dialogue Response Events
The dialogue response events script allows for triggering unity events based on the response chosen in a dialogue.  
It has the following features:

- **Event Links** *List\<ResponseLink\>*
Holds events for every Dialogue Data added in the list.  
Every ResponseLink has the following features:
    - **Data** *Dialogue Data*  
    A reference of the dialogue to detect responses on and link events to.
    - **Response Events** *List\<ResponseEvent\>*  
    A list of Unity Events, automatically linked to the responses from the Dialogue Data.
    - **Refresh** *Inspector Button*  
    Force syncs the unity events in the response events list with the dialogue data.

### Dialogue Data
Dialogue Data is a scriptable object script that is the main method of creating content for the dialogue system.  
It has the following features:

- **Dialogue** *List\<DialogueMessage\>*  
Holds the content of a dialogue, has the following elements:
    - **Speaker** *string*  
    Dictates what is filled into the *speaker* field.
    - **Dialogue** *string*  
    Dictates what is filled into the *dialogue* field.
    - **Unskippable** *bool*  
    Dictates if the dialogue is allowed to be skipped.
    
- **Responses** *List\<Response\>*  
Holds the responses for this dialogue. If left empty, dialogue will end after last text.

### Response
Holds data for a response, has the following features:  

- **Response Title** *string*  
Name of the response, this will also be filled into the textfield on the response button.

- **Dialogue Data** *DialogueData*  
Holds a reference to the follow up dialogue, if left empty, dialogue will end when response is chosen.

### Response Event
Holds data for when response is chosen, holds the **On Response** *UnityEvent*.

## Simple Inventory
The Simple Inventory system can keep track of gaining and using items and keeps track of item counts. 
The system has no build in visuals. 
The simple inventory is not a MonoBehavior, to use it, add it as a variable to a different MonoBehavior.  
It has the following features:

- **inventory** *UnityDictionary*  
Dictionary of every item and their respective count.

To interact with the system, use the following functions:

- **UseItem**(*item*, *count*(optional)) returns *bool*  
This function is used to remove items from the inventory.  
The *item* parameter determines what item will be added to the inventory, it's type is set by the class.  
The *count* parameter determines how many of the *item* will be removed from the inventory.  
If the inventory has the item **and** has enough of the item, items will be removed and the function will return *True*, otherwise returns *False*.

- **GainItem**(*item*, *count*)  
This function is used to add items to the inventory.  
The *item* parameter determines what item will be added to the inventory, it's type is set by the class.  
the *count* parameter determines how many of the *item* will be added to the inventory.

## Health Manager
The Health Manager system that handles an (in)visible healthbar. 
Use the *TakeDamage* and *Heal* functions to interact with the system.  
It has the following features:

- **Health** *float*  
Determines the health the object starts with.
- **Max Health** *float*  
Determines the maximum health. If set to 0 or lower, *health* will be used as maximum health.

- **Health Bar Mode** *enum*  
Determines how and if health is displayed, has the following settings:
    - *None*: health will not be displayed.
    - *Slider*: *target slider* will be used to display health.
    - *Transform*: *target transform* will be scaled to display health.

- **Hit On Death** *bool*  
When set to *True*, *OnHit* event will be invoked when *OnDeath* is invoked. When set to *False*, does nothing.

- **Allow Over Heal** *bool*  
When set to *True*, the object's health is allowed to surpass max health. When set to *False*, does nothing.

- **Allow Neg Damage** *bool*  
When set to *True*, the object is allowed to heal through taking negative damage values. When set to *False*, object cannot take less then 0 damage.

- **Allow Neg Heal** *bool*  
When set to *True*, the object is allowed to take damage through healing negative healing values.  When set to *False*, object cannot heal less then 0.

- **Target Slider** *Slider*  
Only used when *Health Bar Mode* is set to *Slider*. Will be used to display health. 
When using the slider, the following settings are recommended:
    - on the slider component, set *Interactable* to *False*.
    - Set the *Left* and *Right* padding on the *Fill Area* object to 0. The *Fill Area* is a child of created object by default.
    - Set the width of the *Fill* object to 0. The *Fill* object is a child of the *Fill Area* object, which is a child of the created object by default.
    - Delete the *Handle Slide Area* object. The *Handle Slide Area* is a child of the created object by default.
- **Fill Image** *Image*  
Only used when *Health Bar Mode* is set to *Slider*. This is the target image of which the color will be changed based on the *Gradient*.  
When using the standard UI slider, this should be set to the *Fill* object, which can be found under the *Fill Area* object.
- **Gradient** *Gradient*  
A gradient that is used to color the fill image. The leftmost color is used when the healthbar is full and the rightmost when the healthbar is empty.

- **Target Transform** *Transform*  
Only used when *Health Bar Move* is set to *Transform*. Will be scaled on the local x-axis to display health.

- **On Hit** *UnityEvent\<float\>*  
Will be invoked when damage is taken. Will *not* be invoked when the damage resulst in death, unless *Hit On Death* is set to *True*.  
Passes the amount of damage taken as a float parameter.

- **On Heal** *UnityEvent\<float\>*  
Will be invoked when object is healed. Passes the amount healed as a float parameter.

- **On Death** *UnityEvent*  
Will be invoked when damage taken results in health reaching 0 or lower.

## Sound Manager
The Sound Manager is a *singleton* system for playing sounds.  
To use the system through script, use the following pattern:  
```
AudioManager myAudioManager = AudioManager.instance;
```
It should be noted that this only works so long there is a Sound Manager script attached to an object in the current scene.  
It has the following features:

- **Sounds** *UnityDictionary\<string, Sound\>*  
Dictionary that stores settings for every sound effect in this system. To Add a new sound to the system, add a new entry to the dictionary.  
Because this is a dictionary, each *Key* must be unique. Each *Key* is associated with a *Sound*.  
A *Sound* has the following features:  
    - **Clip** *AudioClip*  
    The sound that can be played.
    - **Output** *Audio Mixer Group*  
    The output audio mixer group, works identical to the *AudioSource* output mixer group.
    - **Volume** *float*  
    The volume of the sound.
    - **Pitch** *float*  
    The pitch of the sound.
    
To Interact with the system, use the following functions:

- **Play**(*name*)
Looks for a sound in the *Sounds* dictionary with a key that matches *name*, if one is found, it is played.  
If no sound is found, an error will be thrown.

## Music Manager
The Music Manager is a *singleton* system for playing music. This system uses *DontDestroyOnLoad* and can be placed anywhere in the hierarchy.  
To use the system through script, use the following pattern:
```
MusicManager myMusicManager = MusicManager.instance;
```
It should be noted that this only works so long there is a Sound Manager script attached to an object in the current scene.  
It has the following features:

- **Tracks** *UnityDictionary\<string, Sound\>*  
Dictionary that stores settings for every music track in this system. To Add a new track to the system, add a new entry to the dictionary.  
Because this is a dictionary, each *Key* must be unique. Each *Key* is associated with a *Sound*.  
A *Sound* has the following features:  
    - **Clip** *AudioClip*  
    The sound that can be played.
    - **Volume** *float*  
    The volume of the sound.
    - **Pitch** *float*  
    The pitch of the sound.
    
- **Mute Time** *float*  
Determines the time it takes for the currently playing track to be muted when switching tracks.

- **Transition Time** *float*  
Determines the time it takes for the new track to reach the desired volume when switching tracks.
    
To Interact with the system, use the following functions:

- **SwitchTrack**(*name*)  
Looks for a music track in the *Tracks* dictionary with a key that matches *name*. 
If one is found, the current music track will be muted, the desired track will start playing and is unmuted.  
If nothing is found, an error will be thrown.

# ==Utils==
## Look At 2D
LookAt2D is a class that handles looking towards objects in 2D space, it also supports looking towards UI elements and looking towards the mouse.

To utilize this class, use the following functions:  

- **LookAtTransform**(*target*, *lookAt*) returns *Quaternion*  
Returns rotation where *target* transform's x positive looks towards *lookAt* position.  
lookAt can both be a vector3 or a transform.  
Example code:
```
transform.rotation = LookAt2D.LookAtTransform(transform, myVector3);
```

- **LookAtMouse**(*target*, *targetCamera* (optional)) returns *Quaternion*  
Returns rotation where *target* transform's x positive looks towards the mouse cursor.  
TargetCamera is the camera through which the mouse position in world space is determined, if left empty, Camera.main will be used.  
Example code:  
```
transform.rotation = LookAt2D.LookAtMouse(transform);
```

- **LookAtRectTransform(*target*, *lookAt*, *targetCamera*)** return *Quaternion*  
Returns rotation where *target* transform's x positive looks towards *lookAt* rect transform.  
TargetCamera is the camera through which the rect transform position in world space is determinded, if left empty, Camera.main will be used.  
Example code:  
```
transform.rotation = LookAt2D.LookAtRectTransform(transform, myRectTransform);
```

## Weighted Chance
A class for handling weighted random chances.  
Each option in weighted chance has the following features:  

- **option** *T*  
The option to be returned when entry is chosen.

- **chance** *float*  
The comparative chance of option being chosen.  
Example: entry 1 with chance = 3, and entry 2 with chance = 1. In this example, entry 1 would have a 75% chance of being chosen and entry 2 would have a 25% chance.

To utilize this class use the following functions:

- **GetRandomEntry** returns *T*  
Returns random entry from *chances* using weighted chance.  
Retrun type is determined by class.  
Example code:
```
public class MyClass {

    public WeightedChance<string> chances;
    
    //function is externally called by, for example, Universal Input Receiver
    public void ChooseOption() {
        Debug.Log(chances.GetRandomEntry()); //gets a random entry and logs result
    }
}
```

## Unity Dictionary
A class that integrates the Dictionary class into the unity editor.  
To utilize the class, use it the same as you would a dictionary.

## Collection Utils
A class with some utlity functions for collections.  
Has the following functions:

- **GetKeyFromValue**(*dictionary*, *value*) returns *key*  
Searched the dictionary for a key that has a mathing *value*, returns *key* if one is found, else returns default.

## Message Debugger
A class for debugging, particularly usefull for debugging UnityEvents.  
Has the following functions:

- *DebugMessage*(*msg*)  
Debugs the *msg*.