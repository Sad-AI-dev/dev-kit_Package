### [found in: Dialogue System](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/DialogueSystem/DialogueSystem.md)
## Dialogue Activator
The Dialogue Activator is used for starting a dialogue sequence.  
It has the following features:

- **Data** *DialogueData*  
When *StartDialogue* is Invoked, this dialogue data will be used as a starting point for the dialogue.

It has the following functions:

- **StartDialogue**(targetUI *DialogueUI*)  
Used to start a dialogue. Takes the target dialogueUI as a paramter.

- **SetDialogueData**(data *DialogueData*)  
Used to change which dialogue is activated when *StartDialogue* is called.