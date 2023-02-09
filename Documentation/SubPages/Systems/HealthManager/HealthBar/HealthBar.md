### [found in: HealthManagerSystem](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/HealthManager/HealthManagerSystem.md)
## Health Bar
An abstract class for showing changes in health.  
To create a custom HealthBar, create a script that inherits from this class.  
It has the following functions:

**UpdateHealthBar**(percentage *float*)  
An abstract function to be overwritten.  
*percentage* is a number between 1 and 0, where 1 is full health and 0 is death.