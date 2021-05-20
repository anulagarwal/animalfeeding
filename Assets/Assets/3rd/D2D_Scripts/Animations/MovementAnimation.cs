using D2D.Common;
using D2D.Utilities;
using D2D.Utils;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace D2D.Animations
{
    public class MovementAnimation : DAnimation<Vector3, Vector3, VectorOptions>
    {
        [SerializeField] protected Axis _axis;
        [SerializeField] private bool _isFrom;
        [SerializeField] private Vector3 _endPoint;

        public bool IsEndPointMode { get; private set; }

        [ContextMenu("Switch desired mode")]
        private void ToggleMode() => IsEndPointMode = !IsEndPointMode;

        protected override TweenerCore<Vector3, Vector3, VectorOptions> CreateAnimation()
        {
            float length = To.RandomFloat();
            var destination = new Vector3(length, 0);

            if (_axis == Axis.Y)
            {
                destination = new Vector3(0, length);
            }
            else if (_axis == Axis.Z)
            {
                destination = new Vector3(0, 0, length);
            }

            if (IsEndPointMode)
            {
                destination = _endPoint;
            }

            TweenerCore<Vector3, Vector3, VectorOptions> tween;

            if (_isFrom)
            {
                Vector3 endPoint = destination;
                if (_isRelative)
                {
                    endPoint += transform.position;
                }
                
                tween = transform.DOMove(transform.position, CalculatedDuration).From(endPoint);
            }
            else
            {
                tween = transform.DOMove(destination, CalculatedDuration);
            }
            
            return tween;
        }
    }
}