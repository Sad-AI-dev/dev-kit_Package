### [found in: Behaviours](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours.md)
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

It has the following functions:

- **StartFade**()  
Used to start fading the Canvas Group.

- **StopFade**()  
Used to pause the current fade behaviour. Use the *StartFade* function to resume.
