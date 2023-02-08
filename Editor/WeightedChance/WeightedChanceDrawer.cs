using UnityEngine;
using UnityEditor;
using DevKit;

[CustomPropertyDrawer(typeof(WeightedChance<>))]
public class WeightedChanceDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property.FindPropertyRelative("chances"), label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        EditorGUI.PropertyField(position, property.FindPropertyRelative("chances"), label, true);

        EditorGUI.EndProperty();
    }
}
