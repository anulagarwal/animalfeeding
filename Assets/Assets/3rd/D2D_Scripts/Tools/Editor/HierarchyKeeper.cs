using System;
using System.Collections.Generic;
using System.Linq;
using D2D.Gameplay;
using D2D.Utilities;
using D2D.Utils.Data;
using UnityEditor;
using UnityEngine;

namespace D2D.Tools
{
    public class HierarchyKeeper : EditorWindow
    {
        private static readonly string[] ExcludingTags = 
        {
            "Respawn"
            ,"Finish"
            ,"EditorOnly"
            ,"MainCamera"
            ,"Player"
            ,"GameController"
        };

        // private static readonly Type[] SiblingOrder =
        // {
        //     typeof(Level)
        //     ,typeof(Canvas)
        //     ,typeof(Player)
        // };

        private static int _siblingIndex;
        
        private void OnEnable()
        {
            if (!ToolsSettings.Instance.isOn)
                return;

            Keep();
        }

        [MenuItem("D2D/Keep hierarchy &.")]
        public static void Keep()
        {
            if (!ToolsSettings.Instance.isOn)
                return;
            
            ResetSibling();

            PushSibling<Level>();
            PushSibling<Canvas>();

            var separatorName = ToolsSettings.Instance.separatorName;
            var separator = GameObject.Find(separatorName);
            if (separator == null)
                separator = new GameObject(separatorName);
            
            PushSibling(separator.transform);
            PushSibling<Player>();

            foreach (var tag in UnityEditorInternal.InternalEditorUtility.tags)
            {
                if (ExcludingTags.Contains(tag))
                    continue;
                
                var folder = GameObject.Find(tag);
                if (folder == null)
                    folder = new GameObject(tag);

                var tagged = GameObject.FindGameObjectsWithTag(tag);
                tagged.ForEach(t => t.transform.parent = folder.transform);
                
                if (tagged.IsNullOrEmpty())
                    DestroyImmediate(folder);
            }
        }

        private static void PushSibling(Transform target)
        {
            if (target == null)
                return;
            
            target.SetSiblingIndex(_siblingIndex);
            _siblingIndex++;
        }
        
        private static void PushSibling<T>() where T: Component
        {
            PushSibling(FindObjectOfType<T>()?.transform);
        }

        private static void ResetSibling()
        {
            _siblingIndex = 0;
        }
    }
}