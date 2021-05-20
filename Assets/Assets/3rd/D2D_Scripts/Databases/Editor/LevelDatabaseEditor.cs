using UnityEditor;
using UnityEngine;

namespace D2D.Databases
{
    [CustomEditor(typeof(LevelDatabase))]
    public class LevelDatabaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var db = (LevelDatabase) target;

            if (!Application.isPlaying)
                return;
            
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.IntField("Recent level", db.RecentLevel);
            EditorGUI.EndDisabledGroup();
        }
    }
}