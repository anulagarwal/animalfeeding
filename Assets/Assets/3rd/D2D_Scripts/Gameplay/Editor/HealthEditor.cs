using D2D.Utilities;
using D2D.Utils;
using UnityEditor;
using UnityEngine;

namespace D2D.Gameplay
{
    [CustomEditor(typeof(Health))]
    public class HealthEditor : SuperEditor
    {
        public override void OnInspectorGUI()
        {
            // Draw serialized: 
            
            serializedObject.Update();

            var health = (Health) target;

            ShowProperty(health.IsHealthDataMode ? "_healthData" : "_maxPoints", 
                health.IsHealthDataMode ? "Data" : "Max Points");

            if (health.ParticlesAreEnabled)
            {
                EditorGUILayout.Space(10);
                ShowProperty("_hitEffect", "Hit Effect");
                ShowProperty("_deathEffect", "Death Effect");
            }

            serializedObject.ApplyModifiedProperties();
            
            // Finish drawing.

            if (!Application.isPlaying)
                return;
            
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.FloatField("Current points", health.CurrentPoints);
            EditorGUI.EndDisabledGroup();
        }

        private static void DrawCurrentPointsLabel(Health health)
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.FloatField("Current points", health.CurrentPoints);
            EditorGUI.EndDisabledGroup();
        }

    }
}