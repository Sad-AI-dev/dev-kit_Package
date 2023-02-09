### [found in: Dialogue System](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/DialogueSystem/DialogueSystem.md)
## Dialogue UI
The Dialogue UI is the cornerstone of the dialogue system, it handles the displaying of dialogue data to the UI and showing responses.  
It has the following features:

- **Dialogue Box** *GameObject*  
The GameObject that holds everything related to displaying dialogue. This object is disabled / enabled based on if dialogue is active.

- **Dialogue Label** *TMP_Text*  
The text element that displays the dialogue content. This element should be a child of the dialogue box.  
Small note, the system does not check if dialogue from a dialogueSO fits in this label. 
It is recommended to either automatically scale text using the *Auto Size* feature from TMP_Text or handle overflow in some other way.

- **Name Label** *TMP_Text*  
The text element that displays the name of who is speaking. This element should be a child of the dialogue box.  
Small note, the system does not check is a name will fit, so use of the *Auto Size* feature from TMP_Text is recommended.

- **On Dialogue Start** *UnityEvent*  
Unity Event that is Invoked when a new dialogue is started. Does *not* trigger when picking a response results in more dialogue.

- **On Dialogue End** *UnityEvent*  
Unity Event that is Invoked when dialogue ends.

It has the following functions:

- **AdvanceDialogue**()  
Used to advance the currently active dialogue.