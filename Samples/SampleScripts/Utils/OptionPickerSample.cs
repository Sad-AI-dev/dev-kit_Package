using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DevKit;

public class OptionPickerSample : MonoBehaviour
{
    public OptionPicker<string> stringPicker;

    public UnityEvent<string> onPickedOption;

    public void PickOption()
    {
        onPickedOption?.Invoke(stringPicker.GetOption());
    }
}
