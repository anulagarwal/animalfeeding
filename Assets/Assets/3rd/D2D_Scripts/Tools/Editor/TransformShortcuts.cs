using UnityEditor;
using UnityEngine;

namespace D2D.Tools
{
    public class TransformShortcuts : EditorWindow
    {
        [MenuItem("D2D/Reset transform %/")]
        private static void ResetTransform()
        {
            GameObject obj = Selection.activeGameObject;
            
            if (obj == null)
                return;

            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;

            Debug.Log("Transform reseted.");
        }
    }
}