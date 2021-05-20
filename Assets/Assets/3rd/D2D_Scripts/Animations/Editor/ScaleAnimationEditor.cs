using DG.Tweening.Plugins.Options;
using UnityEditor;
using UnityEngine;

namespace D2D.Animations
{
    [CustomEditor(typeof(ScaleAnimation))]
    [CanEditMultipleObjects]
    public class ScaleAnimationEditor : DAnimationEditor<Vector3, Vector3, VectorOptions>
    {
       
    }
}