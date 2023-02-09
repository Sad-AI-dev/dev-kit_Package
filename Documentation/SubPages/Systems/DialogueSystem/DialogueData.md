### [found in: Dialogue System](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/DialogueSystem/DialogueSystem.md)
## Dialogue Data
Dialogue Data is a scriptable object script that is the main method of creating content for the dialogue system.  
It has the following features:

- **Dialogue** *List\<DialogueMessage\>*  
Holds the content of a dialogue, has the following elements:
    - **Speaker** *string*  
    Dictates what is filled into the *speaker* field.
    - **Dialogue** *string*  
    Dictates what is filled into the *dialogue* field.
    - **Unskippable** *bool*  
    Dictates if the dialogue is allowed to be skipped.
    
- **Responses** *List\<Response\>*  
Holds the responses for this dialogue. If left empty, dialogue will end after last text.