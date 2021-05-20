using D2D.Utilities;
using D2D.Utils;
using UnityEditor;

namespace D2D.UI
{
    [CustomEditor(typeof(DButton))]
    public class ButtonEditor : SuperEditor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            ShowProperty("Clicked");

            var button = target as DButton;
            
            if (button.needShowAdvancedProperties)
            {
                ShowProperty("PointerDown");
                ShowProperty("PointerUp");
                ShowProperty("MouseEnter");
                ShowProperty("MouseExit");
                
                EditorGUILayout.Space();
                
                ShowProperty("_disabledAlpha");
                ShowProperty("_clickIsPointerDown");
            }
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}