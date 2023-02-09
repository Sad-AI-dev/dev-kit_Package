### [found in: Behaviours](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours.md)
## Object Detector
Used to detect if something is overlapping with an attached (2D) trigger collider.  
It has the following features:

- **On Detect First Object** *UnityEvent*  
Event that is Invoked when the first object is found.
- **On Detect Object** *UnityEvent*  
Event that is Invoked every time a object is detected.
- **On Leave Last Object** *UnityEvent*  
Event that is Invoked when last object goes out of range.  

- **Whitelist Tags** *List\<string\>*  
List of tags that are allowed when an object is detected.
- **Blacklist Tags** *List\<string\>*  
List of tags that are ignored when an object is detected.  
Only used when *Whitelist Tags* is empty.

**A quick note on use with Controllers**  
Controllers always setup event listeners on their own for the object detectors. The Unity Events are purely for custom behaviour.