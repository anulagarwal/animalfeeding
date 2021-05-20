using D2D.Utilities;
using D2D.Utils;
using UnityEditor;
using UnityEngine;

namespace D2D.Gameplay
{
    [CustomEditor(typeof(Level))]
    public class LevelEditor : SuperEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            // // Draw serialized: 
            //
            // serializedObject.Update();
            //
            // var level = (Level) target;
            //
            // serializedObject.ApplyModifiedProperties();
            //
            // // Finish drawing.
            //
            // EditorGUI.BeginDisabledGroup(true);
            // EditorGUILayout.FloatField("Level number", level.LevelNumber);
            // EditorGUI.EndDisabledGroup();
        }
    }
}