using D2D.Common;
using D2D.Utilities;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace D2D
{
    public abstract class TrackableValueLabel<T> : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Transform _icon;

        private TrackableValue<T> _trackable;
        
        public abstract TrackableValue<T> Trackable { get; }

        private float _timeSinceStart;

        private Vector3 _iconOriginalLocalScale;

        private void OnEnable()
        {
            _trackable = Trackable;
            
            _iconOriginalLocalScale = _icon.localScale;
            
            _timeSinceStart = Time.time;
            
            Debug.Log(_trackable.Value);
            
            _trackable.Changed += Redraw;
            
            Redraw(_trackable.Value);
        }

        private void OnDisable()
        {
            _trackable.Changed -= Redraw;
        }

        private void Redraw(T newValue)
        {
            _label.text = ValueToText(newValue);
            
            if (Time.time - _timeSinceStart < .1f)
                return;

            _icon.DOScale(_iconOriginalLocalScale, 0);
            _icon?.PunchUI();
        }

        protected virtual string ValueToText(T value)
        {
            return value.ToString();
        }
    }
}