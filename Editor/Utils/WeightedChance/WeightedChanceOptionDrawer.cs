using UnityEngine;
using UnityEditor;
using DevKit;

//[CustomPropertyDrawer(typeof(WeightedChance<>.WeightedOption))]
public class WeightedChanceOptionDrawer : PropertyDrawer
{
    //public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    //{
        //EditorGUI.BeginProperty(position, label, property);

        ////Draw label
        //position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        //// Don't make child fields be indented
        //int indent = EditorGUI.indentLevel;
        //EditorGUI.indentLevel = 0;

        //// Calculate rects
        //float totalWidth = position.width - 5;
        //Rect optionRect = new Rect(position.x, position.y, totalWidth * 0.8f, position.height);
        //Rect chanceRect = new Rect(position.x + totalWidth * 0.8f + 5, position.y, position.width - (totalWidth * 0.8f), position.height);

        //// Draw fields - pass GUIContent.none to each so they are drawn without labels
        //EditorGUI.PropertyField(optionRect, property.FindPropertyRelative("option"), GUIContent.none);
        //EditorGUI.PropertyField(chanceRect, property.FindPropertyRelative("chance"), GUIContent.none);

        //// Set indent back to what it was
        //EditorGUI.indentLevel = indent;

        //EditorGUI.EndProperty();
    //}
}
