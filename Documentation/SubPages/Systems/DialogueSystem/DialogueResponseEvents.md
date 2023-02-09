### [found in: Dialogue System](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/DialogueSystem/DialogueSystem.md)
## Dialogue Response Events
The dialogue response events script allows for triggering unity events based on the response chosen in a dialogue.  
It has the following features:

- **Event Links** *List\<ResponseLink\>*
Holds events for every Dialogue Data added in the list.  
Every ResponseLink has the following features:
    - **Data** *Dialogue Data*  
    A reference of the dialogue to detect responses on and link events to.
    - **Response Events** *List\<ResponseEvent\>*  
    A list of Unity Events, automatically linked to the responses from the Dialogue Data.
    - **Refresh** *Inspector Button*  
    Force syncs the unity events in the response events list with the dialogue data.