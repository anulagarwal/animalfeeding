using D2D.Utilities;
using D2D.Utils;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace D2D.Animations
{
    public class ScaleAnimation : DAnimation<Vector3, Vector3, VectorOptions>
    {
        protected override TweenerCore<Vector3, Vector3, VectorOptions> CreateAnimation()
        {
            return transform.DOScale(To.RandomFloat(), CalculatedDuration);
        }
    }
}