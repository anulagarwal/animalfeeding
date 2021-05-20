using UnityEditor;
using UnityEngine;

namespace D2D.Utilities
{
    public class SuperEditor : Editor
    {
        protected void ShowProperty(string propertyName, string text="")
        {
            var property = serializedObject.FindProperty(propertyName);

            if (text == "")
            {
                text = propertyName.Replace('_', ' ').Trim();
                text = (text[0].ToString().ToUpper() + text.Remove(0, 1));
            }
            
            EditorGUILayout.PropertyField(property, new GUIContent(text));
        }
    }
}