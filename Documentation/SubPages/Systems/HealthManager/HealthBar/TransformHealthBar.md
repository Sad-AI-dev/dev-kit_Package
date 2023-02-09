### [found in: HealthManagerSystem](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/HealthManager/HealthManagerSystem.md)
## Transform Health Bar
Inherits from the Health Bar class. Displays health by scaling a Transform.  
It has the following features:

- **Target Transform** *Transform*  
Transform to be scaled.  
If left empty, current transform will be used.

- **scaleX** *bool*  
If set to *true*, scales the *targetTransform* over the x-axis.

- **scaleY** *bool*  
If set to *true*, scales the *targetTransform* over the Y-axis.

- **scaleZ** *bool*  
If set to *true*, scales the *targetTransform* over the Z-axis.

It has the following functions:

**UpdateHealthBar**(percentage *float*)  
An abstract function to be overwritten.  
*percentage* is a number between 1 and 0, where 1 is full health and 0 is death.