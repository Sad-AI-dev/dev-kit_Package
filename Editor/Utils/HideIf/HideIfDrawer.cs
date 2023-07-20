using System.Reflection;
using System.Collections;
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
        bool result;

        //look for conditional field
        string conditionalPath = property.propertyPath.Contains(".") ?
            System.IO.Path.ChangeExtension(property.propertyPath, hideIf.conditionalField) :
            hideIf.conditionalField;

        SerializedProperty conditionalProperty = property.serializedObject.FindProperty(conditionalPath);

        if (conditionalProperty != null) {
            result = CheckPropertyType(conditionalProperty);
        }
        else {
            PropertyInfo propertyInfo = property.serializedObject.targetObject.GetType().GetProperty(conditionalPath,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
 
            if (propertyInfo != null) {
                var value = propertyInfo.GetValue(property.serializedObject.targetObject);
                result = CheckPropertyType(value);
            }
            else {
                Debug.LogWarning("HideIf attribute || the field \"" + hideIf.conditionalField + "\" could not be found!");
                result = false;
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
