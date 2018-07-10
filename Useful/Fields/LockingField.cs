namespace ExtendHealth.Ssc.AuthRep.Fields
{
    public class LockingField<T> : IField<T>
    {
        private readonly IField<T> _value;
        private bool _isSettingVariable;

        public LockingField() : this(new Field<T>()) { }

        public LockingField(IField<T> value)
        {
            _value = value;
        }

        public T Value
        {
            get { return _value.Value; }
            set
            {
                if (_isSettingVariable)
                    return;
                _isSettingVariable = true;
                _value.Value = value;
                _isSettingVariable = false;
            }
        }
    }
}
