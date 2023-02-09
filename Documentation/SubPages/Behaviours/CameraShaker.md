### [found in: Behaviours](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours.md)
## Camera Shaker
The Camera shaker is a behaviour that emulates camera shake.  
When using this behaviour, do not change the position of the camera's gameObject, instead use a parent object.  
It has the following functions:

- **ShakeCamera**(duration *float*, magnitude *float*)  
Used to add camera shake. Shakes the gameObject for *duration* in seconds.  
*magnitude* determines the severity of the shake effect.