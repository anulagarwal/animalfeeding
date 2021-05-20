using DG.Tweening.Plugins.Options;
using UnityEditor;
using UnityEngine;

namespace D2D.Animations
{
    [CustomEditor(typeof(FadeAnimation))]
    [CanEditMultipleObjects]
    public class FadeAnimationEditor : DAnimationEditor<Color, Color, ColorOptions>
    {
        
    }
}