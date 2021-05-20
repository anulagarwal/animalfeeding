using D2D.Utilities;
using D2D.Utils;
using DG.Tweening.Plugins.Options;
using UnityEditor;
using UnityEngine;

namespace D2D.Animations
{
    [CustomEditor(typeof(DAnimation<Vector3, Vector3, VectorOptions>))]
    [CanEditMultipleObjects]
    public class DAnimationEditor<T1, T2, T3> : SuperEditor
        where T3 : struct, IPlugOptions
    {
        protected object Target { get; private set; }
        
        public override void OnInspectorGUI()
        {
            // base.OnInspectorGUI();
            
            serializedObject.Update ();

            Target = target;
            var animation = (DAnimation<T1, T2, T3>) target;
            if (animation.isRandomnessSupported)
            {
                ShowRandomFields();
            }
            else
            {
                ShowDefaultFields();
            }

            if (animation.isAdvancedInfoVisible)
            {
                ShowAdvancedInfo();
            }

            serializedObject.ApplyModifiedProperties();
            
            ShowButton();

            if (animation.isAdvancedInfoVisible)
            {
                // ShowAnimationButtons();
            }
        }

        private void ShowAnimationButtons()
        {
            var animation = (DAnimation<T1, T2, T3>) target;
            
            GUILayout.BeginHorizontal("box");
            
            if (GUILayout.Button("Play"))
            {
                animation.Restart(true);
            }
            
            if (GUILayout.Button("Stop"))
            {
                animation.Stop();
            }
            
            GUILayout.EndHorizontal();
        }

        protected virtual void ShowAdvancedInfo()
        {
            ShowProperty("_isPong");
            ShowProperty("_isRelative");
            ShowProperty("_destroyOnFinish");
            ShowProperty("_ease");
            ShowProperty("_playMode");
            
            EditorGUILayout.Space();
            
            var animation = (DAnimation<T1, T2, T3>) target;
            if (animation.isRandomnessSupported)
            {
                ShowProperty("_startDelay", "Start Delay");
                ShowProperty("_delayBetweenCycles", "Delay Between");
            }
            else
            {
                ShowProperty("startDelay", "Start Delay");
                ShowProperty("delayBetweenCycles", "Delay Between");
            }
        }

        private void ShowButton()
        {
            var animation = (DAnimation<T1, T2, T3>) target;
            
            EditorGUILayout.Space();
            
            GUILayout.BeginHorizontal("box");

            string caption = "Show advanced";
            if (animation.isAdvancedInfoVisible)
                caption = "Hide advanced";
            if (GUILayout.Button(caption))
            {
                animation.isAdvancedInfoVisible = !animation.isAdvancedInfoVisible;
            }

            caption = "Show random";
            if (animation.isRandomnessSupported)
                caption = "Show regular";
            if (GUILayout.Button(caption))
            {
                animation.isRandomnessSupported = !animation.isRandomnessSupported;
            }
            
            GUILayout.EndHorizontal();
        }

        private void ShowRandomFields()
        {
            ShowProperty("_to");
            ShowProperty("_duration");
        }

        protected virtual void ShowDefaultFields()
        {
            ShowProperty("to");
            ShowProperty("duration");
        }
    }
}