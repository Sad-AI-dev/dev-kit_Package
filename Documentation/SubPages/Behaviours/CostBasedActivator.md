### [found in: Behaviours](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours.md)
## Cost Based Activator
The Cost Based Activator is a procedural behaviour that can invoke unity events based on their assigned costs.  
This behaviour is ideal for systems such as procudural infinite wave spawners.  
It has the following features:

- **Budget** *int*  
The budget of the behaviour, which it will use the next time it is activated.  
This is also the starting value for the behaviour.

- **Activate On Start** *bool*  
When set to *true*, calls the *Activate* function on start. When false, does nothing.

- **Budget Gain** *int*  
The amount that *Budget* will increase by for the next time the *Activate* function is called.

- **Gain Rampup** *int*  
The amount that *Budget Gain* is increased by the next time Gain Rampup is triggered.

- **Gain Rampup Frequency** *int*  
Determines how often Gain Rampup is triggered. Measured in the amount of times the *Activate* function needs to be invoked before rampup is triggered. For Example: 
    - when set to 0, rampup will never trigger.
    - when set to 1, rampup will trigger every time *Activate* is called.
    - when set to 2, rampup will trigger every other time *Activate* is called.
    - etc...
    
- **Activate Mode** *enum*  
Determines when behaviour is activated. Has the following options:
    - *Manual*: only activates when Activate() is called.
    - *Interval*: activates periodically. Timing is determined by *Activate Interval Time*.
    
- **Activate Interval Time** *float*  
Only used when *Activate Mode* is set to *Interval*.  
Determines the time the behaviour waits before activating again.

- **Save Mode** *enum*  
Determines how the save feature is activated. Has the following options:
    - None: save feature will never be activated.
    - Random: save feature will randomly be activated.
    - Interval: save feature will be activated once per set interval.
    - Interval_Random: similar to 'Interval', but interval time is randomly picked."
    
- **Save Chance** *float*  
Only used when 'Save Mode' is set to *Random*.  
Determines the chance for the save behaviour to activate, in percentage.

- **Save Interval** *int*  
Only used when *Save Mode* is set to *Interval*.  
Determines how many times *Activate()* needs to be called before save feature is activated.

- **Min Rand Interval** *int*  
Only used when *Save Mode* is set to *Interval_Random*.  
Determines the minimum value the interval can be (inclusive).

- **Max Rand Interval** *int*  
Only used when *Save Mode* is set to *Interval_Random*.  
Determines the maximum value the interval can be (inclusive).

- *Min Save Percent* *float*  
Determines the minimum percent of budget to be saved for next time when save feature is activated.

- *Max Save Percent*
Determines the maximum percent of budget to be saved for next time when save feature is activated.

- **Options** *List\<Option\>*  
The list of options that the behaviour can 'purchase' from.  
Other scripts cannot interface with this list, use the *AddOption* and *RemoveOption* functions instead.  
Each *Option* has the following features:
    - **Name** *string*  
    The name of the option, only used for organizational purposes.
    - **Price** *int*  
    The amount of budget it costs for the behaviour to 'purchase' this option.
    - **On Select** *UnityEvent*  
    The event that is invoked when the option is 'purchased'.

It has the following functions:

- **Activate**()  
Activates a single iteration of the behaviour. Can be broken down to 3 steps:
    1. 'Purchase' options using budget.
    2. Gain new budget.
    3. Activate save feature (if applicable).
    4. Repeat (if applicable)
    
- **Stop**()  
Stops the behaviour if *Activate Mode* is set to *Interval*. Use *Activate* to resume.
    
- **AddOption**(option *Option*)  
Adds an option to the *Options* list.

- **RemoveOption**(option *Option*) returns *bool*  
Attempts to remove an option from the *Options* list.  
Returns *true* is a matching option was found and removed.  
Returns *false* if no matching option was found.