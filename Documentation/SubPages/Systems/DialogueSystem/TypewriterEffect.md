### [found in: Dialogue System](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Systems/DialogueSystem/DialogueSystem.md)
## Typewriter Effect
The typewriter effect script handles the display effect, which displays each character in order, for the dialogue text.  
It has the following features:

- **Delay** *float*  
The delay in seconds between each character being displayed.

- **Punctuations** *List\<Punctuation\>*  
The punctuations list controls additionals delays for specific characters.  
It has the following elements:
    - **Punctuations** *List\<char\>*  
    Holds the characters that should trigger the additional delay.
    - **Wait Time** *float*  
    The additional time that should be waited when the punctuation is encountered.