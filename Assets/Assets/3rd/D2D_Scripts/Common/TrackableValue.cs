using System;

namespace D2D.Common
{
    /// <summary>
    /// The value which have on change event, so other scripts will know
    /// when value change
    /// </summary>
    public class TrackableValue<T>
    {
        public event Action<T> Changed; 
        
        public virtual T Value
        {
            get => _value;
            set
            {
                if (!_value.Equals(value))
                {
                    _value = value;
                    Changed?.Invoke(value);
                }
            }
        }
        private T _value;

        public virtual void Init(T newValue)
        {
            _value = newValue;
        }
    }
}