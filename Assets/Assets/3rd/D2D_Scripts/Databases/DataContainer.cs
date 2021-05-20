using D2D.Common;

namespace D2D.Databases
{
    public class DataContainer<T> : TrackableValue<T>
    {
        private readonly string _key;
        private readonly T _defaultValue;

        public override T Value
        {
            get => ES3.Load(_key, _defaultValue);
            set
            {
                base.Value = value;
                
                ES3.Save(_key, value);
            }
        }

        public override void Init(T newValue)
        {
            base.Init(newValue);
            
            Value = newValue;
        }

        public bool IsEmpty => ES3.KeyExists(_key);

        public DataContainer(string key, T defaultValue)
        {
            _key = key;
            _defaultValue = defaultValue;
        }

        public DataContainer(T defaultValue)
        {
            _key = GetType().FullName;
            _defaultValue = defaultValue;
        }

        public void Clear()
        {
            ES3.DeleteKey(_key);
        }
    }
}