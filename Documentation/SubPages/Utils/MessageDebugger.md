### [found in: Utils](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Utils.md)
## Class Name
## Message Debugger
A class for debugging, particularly usefull for debugging UnityEvents.  
It has the following functions:

- **DebugMessage**(msg *string*)  
Debugs the *msg*.  
Has various varients that allow for value debugging. It is suggested to use these with *Dynamic Variable* in Unity Events.

- **DebugMessageGeneric**(T *input*)
Debugs the value of *input* using *ToString()*.