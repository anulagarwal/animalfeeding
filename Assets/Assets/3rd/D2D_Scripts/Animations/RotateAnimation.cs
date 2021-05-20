using D2D.Common;
using D2D.Utilities;
using D2D.Utils;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace D2D.Animations
{
    /// <summary>
    /// More for UIs
    /// </summary>
    public class RotateAnimation : DAnimation<Quaternion, Vector3, QuaternionOptions>
    {
        [SerializeField] private Axis _axis = Axis.Z;
        [SerializeField] private bool _isIncremental;

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();

            isIncremental = _isIncremental;
        }

        protected override TweenerCore<Quaternion, Vector3, QuaternionOptions> CreateAnimation()
        {
            Vector3 rotationDestination = new Vector3(_axis == Axis.X ? 1 : 0, 
                _axis == Axis.Y ? 1 : 0, _axis == Axis.Z ? 1 : 0) * To.RandomFloat();

            return transform.DORotate(rotationDestination, CalculatedDuration);
        }
    }
}