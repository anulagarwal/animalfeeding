using System.Linq;
using D2D.Gameplay;
using D2D.Utilities;
using UnityEditor;
using UnityEngine;

namespace D2D.Tools
{
    /// <summary>
    /// Focuses on common gameplay GameObjects, such as player and level.
    /// We can find also by tags. 
    /// </summary>
    public class FastSelector : EditorWindow
    {
        [MenuItem("D2D/Select player &[")]
        public static void SelectPlayer()
        {
            SelectByType<Player>();
        }
        
        // [MenuItem("D2D/Select level &l")]
        public static void SelectLevel()
        {
            SelectByType<Level>();
        }
        
        [MenuItem("D2D/Select canvas &]")]
        public static void SelectCanvas()
        {
            SelectByType<Canvas>();
        }

        [MenuItem("D2D/Ground &g")]
        public static void SelectGround()
        {
            SelectByTag("Ground");
        }

        private static void SelectByType<T>() where T : Component
        {
            var objectOfDesiredType = FindObjectsOfType<T>().Select(o => o.gameObject).ToArray();

            if (!objectOfDesiredType.IsNullOrEmpty())
                Selection.objects = objectOfDesiredType;
        }

        private static void SelectByTag(string tag)
        {
            var objectsWithDesiredTag = GameObject.FindGameObjectsWithTag(tag);

            if (!objectsWithDesiredTag.IsNullOrEmpty())
                Selection.objects = objectsWithDesiredTag;
        }
    }
}