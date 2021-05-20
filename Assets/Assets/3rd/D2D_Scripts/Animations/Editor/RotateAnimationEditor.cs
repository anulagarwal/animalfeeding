using DG.Tweening.Plugins.Options;
using UnityEditor;
using UnityEngine;

namespace D2D.Animations
{
    [CustomEditor(typeof(RotateAnimation))]
    [CanEditMultipleObjects]
    public class RotateAnimationEditor : DAnimationEditor<Quaternion, Vector3, QuaternionOptions>
    {
        protected override void ShowAdvancedInfo()
        {
            ShowProperty("_axis");
            ShowProperty("_isIncremental", "Is Incremental");
            base.ShowAdvancedInfo();
        }
    }
}