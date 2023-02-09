### [found in: Behaviours](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours.md)
## Interval Timer Manager
The interval timer manager is a behaviour that allows for easy setting up and interacting with interval timers.  
It has the following features:

- **Interval Timers** *UnityDictionary\<string, IntervalTimer>*  
List of all timers. Each Timer has the following features:
    - **Activate On Start** *bool*  
    When set to *true*, timer starts on start. Does nothing when set to *false*.
    - **Timer Length** *float*  
    The length of the timer in seconds.
    - **Repeat Count** *int*  
    Determines the amount of times the timer should be repeated. For example:
        - when 0, will not repeat.
        - when 1, timer will repeat once.
        - when set to a negative value, will repeat infinitely.
    - **Timer Length Mode** *enum*  
    Determines how *Timer Length* is calculated when timer repeats.  
    Has the following options:
        - *Set*: uses the *timerLength* variable on repeats.
        - *Random*: uses a random number between *minTimerLength* and *maxTimerLength*.
    - **Min Timer Length** *float*  
    Only used when *Timer Length Mode* is set to *Random*. The minimum time in seconds *Timer length* can become.
    - **Max Timer Length** *float*  
    Only used when *Timer Length Mode* is set to *Random*. The maximum time in seconds *Timer length* can become.
    - **On Timer Activated** *UnityEvent*  
    The event that is invoked when the timer expires.
    - **On Timer Ended** *UnityEvent*
    This event is invoked when the timer finished repeating for the last time.
    
It has the following Functions:

- **ActivateTimer**(timerName *string*) returns *Coroutine*  
Activates the timer with *Key* *timerName* and returns the activated *Coroutine*.  
If no timer with *Key* *timerName* is found, throws warning and returns *null*.

- **ActivateTimer**(timer *IntervalTimer*) returns *Coroutine*
Activates the *timer* and returns the activated *Coroutine.*

- **GetTimer**(timerName *string*) returns *IntervalTimer*  
Returns the timer with *Key* *timerName*. If no timer with *Key* *timerName* is found, returns *null*.