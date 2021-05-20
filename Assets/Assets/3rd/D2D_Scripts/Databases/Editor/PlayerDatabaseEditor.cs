using UnityEditor;
using UnityEngine;

namespace D2D.Databases
{
    [CustomEditor(typeof(PlayerDatabase))]
    public class PlayerDatabaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var db = (PlayerDatabase) target;

            if (!Application.isPlaying)
                return;
            
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.FloatField("Player money", db.MoneyContainer.Value);
            EditorGUI.EndDisabledGroup();
        }
    }
}