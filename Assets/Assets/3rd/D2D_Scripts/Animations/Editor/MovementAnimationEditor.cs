using DG.Tweening.Plugins.Options;
using UnityEditor;
using UnityEngine;

namespace D2D.Animations
{
    [CustomEditor(typeof(MovementAnimation))]
    [CanEditMultipleObjects]
    public class MovementAnimationEditor : DAnimationEditor<Vector3, Vector3, VectorOptions>
    {
        protected override void ShowAdvancedInfo()
        {
            if (Target == null)
                return;
            
            var anim = Target as MovementAnimation;

            if (anim == null)
                return;

            if (!anim.IsEndPointMode)
            {
                ShowProperty("_axis");
            }

            ShowProperty("_isFrom", "Is From");
            
            base.ShowAdvancedInfo();
        }

        protected override void ShowDefaultFields()
        {
            if (Target == null)
                return;
            
            var anim = Target as MovementAnimation;

            if (anim == null)
                return;
            
            ShowProperty(anim.IsEndPointMode ? "_endPoint" : "to", 
                anim.IsEndPointMode ? "End Point" : "To");
            
            ShowProperty("duration");
        }
    }
}