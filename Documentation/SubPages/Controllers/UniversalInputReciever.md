#### [found in: Controllers](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Controllers.md)
## Universal Input Reciever
allows for setting up of inputs through the editor.  
It supports keycode inputs and codes from the input manager.

The input reciever contains 3 seperate input types:
1. **Button Input**
    - Button inputs are intended for single button inputs, and has the following features:
        - **Name** *string*  
        Used for orginazation in the editor, has no technical purpose.
        - **On Button Down**  *UnityEvent*  
        Invoked when a tracked input is pressed down.
        - **On Button Held** *UnityEvent*  
        Invoked when a tracked input is held down.
        - **On Button Up** *UnityEvent*  
        Invoked when a tracked input is released.  
        
        - **Codes** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for inputs.  
        
        - **Button Codes** *List\<string\>*  
        List of strings, these are input manager codes that are tracked for inputs.  
        
2. **Axis Input**
    - Axis inputs are intended for 2 seperate inputs that act as a singular float axis from -1 to 1. It has the following features:
        - **Name** *string*  
        Used for orginazation in the editor, has no technical purpose.
        - **Output** *UnityEvent\<float\>*  
        Invoked every frame, outputs current axis value.  
        
        - **Pos Input** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for positive inputs along the axis.
        - **Neg Input** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for negative inputs along the axis.  
        
        - **Axis Codes** *List\<string\>*  
        List of strings, these are input manager codes that are tracked for inputs.  
        
        - **Read Mouse Scroll Wheel** *bool*  
        When set to true, reads the mouse scroll wheel as input source. Scrolling up is represented as positive and down as negative.
        
3. **Directional Input**
    - Directional inputs are intended for 4 seperate inputs that act as a singular Vector2 from (-1, -1) to (1, 1). It has the following features:
        - **Name** *string*  
        Used for orginazation in the editor, has no technical purpose.
        - **Output** *UnityEvent\<Vector2\>*  
        Invoked every frame, outputs current directional value.  
        
        - **X Pos Input** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for positive inputs along the X axis.
        - **X Neg Input** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for negative inputs along the X axis.
        - **Y Pos Input** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for positive inputs along the Y axis.
        - **Y Neg Input** *List\<KeyCode\>*  
        List of keycodes, these keycodes are tracked for negative inputs along the Y axis.  
        
        - **X axis Codes** *List\<string\>*  
        List of strings, these are input manager codes that are tracked for inputs along the X axis.
        - **Y axis Codes** *List\<string\>*  
        List of strings, these are input manager codes that are tracked for inputs along the Y axis.  

**A quick note on input reading**  
Due to the nature of tracking multiple inputs at a time, some compromises were made:  
For button inputs, *on button down* and *on button up* can both be Invoked once per frame.  
For axis inputs and directional inputs, when multiple changes are detected on an axis, the input furthest from neutral (0) will be used.