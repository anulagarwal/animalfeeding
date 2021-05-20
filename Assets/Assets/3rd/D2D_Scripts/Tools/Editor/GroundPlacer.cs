using UnityEditor;
using UnityEngine;

namespace D2D.Tools
{
    public class GroundPlacer : EditorWindow
    {
        [MenuItem("D2D/Place &r")]
        public static void Place()
        {
            // var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = SceneView.lastActiveSceneView.camera.ScreenPointToRay(Event.current.mousePosition);
            // //or maybe
            // // Ray ray = HandleUtility.GUIPointToWorldRay (Event.current.mousePosition);
            // if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
            // {
            //     //ray hit object, info stored in hit
            //     Debug.Log("Hit obj: " + hit.transform.gameObject);
            // }
            // else
            // {
            //     //nothing hit by ray
            //     Debug.Log("Click missed");
            // }
            
            RaycastHit hitInfo;
            // Shoot this ray. check in a distance of 10000.
            if (Physics.Raycast(ray, out hitInfo, 10000))
            {
                Debug.Log("Yeah!");
            }
        }
    }
}