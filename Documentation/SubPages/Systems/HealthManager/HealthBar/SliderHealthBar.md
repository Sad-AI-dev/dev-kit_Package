### [found in: HealthManagerSystem](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/HealthManager/HealthManagerSystem.md)
## Slider Health Bar
Inherits from the Health Bar class. Displays health through a UI Slider.  
It has the following features:

- **Target Slider** *Slider*  
Slider to be used to display health. 
When using the slider, the following settings are recommended:
    - on the slider component, set *Interactable* to *false*.
    - Set the *Left* and *Right* padding on the *Fill Area* object to 0. The *Fill Area* is a child of created object by default.
    - Set the width of the *Fill* object to 0. The *Fill* object is a child of the *Fill Area* object, which is a child of the created object by default.
    - Delete the *Handle Slide Area* object. The *Handle Slide Area* is a child of the created object by default.
    
- **Fill Image** *Image*  
This is the target image of which the color will be changed based on the *Gradient*.  
When using the standard UI slider, this should be set to the *Fill* object, which can be found under the *Fill Area* object.

- **Gradient** *Gradient*  
A gradient that is used to color the fill image. The leftmost color is used when the healthbar is full and the rightmost when the healthbar is empty.

It has the following functions:

**UpdateHealthBar**(percentage *float*)  
An abstract function to be overwritten.  
*percentage* is a number between 1 and 0, where 1 is full health and 0 is death.