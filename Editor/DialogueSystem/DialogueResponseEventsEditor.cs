using UnityEngine;
using UnityEditor;
using DevKit;

[CustomEditor(typeof(DialogueResponseEvents))]
public class DialogueResponseEventsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueResponseEvents responseEvents = (DialogueResponseEvents)target;
        if (GUILayout.Button("Refresh"))
        {
            responseEvents.OnValidate();
        }
    }
}
