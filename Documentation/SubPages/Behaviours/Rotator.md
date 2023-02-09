### [found in: Behaviours](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Behaviours.md)
## Rotator
The rotator rotates the gameObject the behaviour is attached to in a predifined local direction.
It has the following features:

- **Rotate Direction** *Vector3*  
Determines (in local space) which direction the object rotates in and how fast.

- **Rotate on Start** *bool*  
If set the true, start rotating when *Start* is Invoked. When set the false, the object only starts rotating after *StartRotate* is Invoked.

It has the following functions:

- **StartRotate**()  
Used to start rotating.

- **StopRotate**()  
Used to stop rotating.