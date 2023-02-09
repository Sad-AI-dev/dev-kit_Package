### [found in: Dialogue System](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/DialogueSystem/DialogueSystem.md)
## Response Handler
The response handler script handles the displaying of responses and triggering response events.  
It has the following features:

- **Response Box** *Rect Transform*  
Rect Transform that holds everything related to response UI elements. Height should be set to 0, as it will automatically be scaled when responses are displayed.

- **Response Container** *Rect Transform*  
Rect Transform that holds the response buttons when they are created.  
This element should be a child of the response box. The rect transform should also be set to *stretch* in both directionts.  
Additionaly, this rect transform should have the *Vertical Layout Group* component, which has the following settings:
    - *Child Alignment* set to *Middle Right*. (is optional)
    - For *Control Child Size*, *Width* set to *true* and *Height* set to *false*.
    - *Use Child Scale* all set to *false*
    - *Child Force Expand* all set to *true*
    - The *Spacing* should be set to 0, spacing can be created through the *Button Template* prefab.
    
- **Button Template** *Rect Transform*  
Rect Transform that will be used as a template for creating the response buttons. Must be a prefab to work as intended.