### [found in: Utils](https://github.com/Sad-AI-dev/dev-kit_Package/blob/main/Documentation/SubPages/Utils.md)
## TimeSpan Converter
A static util for converting time representing *float* values to formatted *string* values.  
It has the following functions:

- **SecondsToTimeSpan**(seconds *float*) returns *TimeSpan*  
Returns *seconds* as a *TimeSpan*.

- **SecondsToFormatString**(seconds *float*, format *string*(optional)) returns *string*  
Returns *seconds* as a formatted timespan string. If *format* is not set, hh:mm:ss will be used.  
For more information on formatting timespan strings, see [the c# documentation](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-timespan-format-strings)