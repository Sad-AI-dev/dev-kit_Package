using System.Reflection;
using UnityEngine;
using UnityEditor;
using DevKit;

[CustomPropertyDrawer(typeof(HideIfAttribute))]
public class HideIfDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //get reference to attribute
        HideIfAttribute hideIf = attribute as HideIfAttribute;
        bool hidden = GetConditionalResult(hideIf, property);

        if (!hidden) {
            EditorGUI.PropertyField(position, property, label, true);
        }
    }

    //========================= Should property be hidden? ======================================
    private bool GetConditionalResult(HideIfAttribute hideIf, SerializedProperty property)
    {
        //look for conditional field
        string conditionalPath = property.propertyPath;
        //change path to look for conditional field within same object
        conditionalPath = conditionalPath.Replace(property.name, hideIf.conditionalField);

        SerializedProperty conditionalProperty = property.serializedObject.FindProperty(conditionalPath);

        bool result = false;
        if (conditionalProperty != null) {
            result = conditionalProperty.boolValue;
        }
        else {
            PropertyInfo propertyInfo = property.serializedObject.targetObject.GetType().GetProperty(conditionalPath, 
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance); //Stole this, have no clue what it does

            if (propertyInfo != null) {
                object value = propertyInfo.GetValue(property.serializedObject.targetObject);
                result = CheckPropertyType(value);
            }
            else {
                Debug.LogWarning("HideIf attribute conditional field could not be found: " + hideIf.conditionalField);
            }
        }
        return result;
    }

    private bool CheckPropertyType(object value)
    {
        if (value is bool) {
            return (bool)value;
        }
        return true;
    }

    //=========================== Property Height =======================
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        HideIfAttribute hideIf = attribute as HideIfAttribute;
        bool hidden = GetConditionalResult(hideIf, property);

        if (!hidden) {
            return EditorGUI.GetPropertyHeight(property, label);
        }
        else {
            //property is not drawn
            //remove space added before and after the property
            return -EditorGUIUtility.standardVerticalSpacing;
        }
    }
}
