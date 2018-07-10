using ExtendHealth.Ssc.Framework;

namespace ExtendHealth.Ssc.AuthRep.Fields
{
    public class AutoNotifyingField<T> : NotifyPropertyChangedBase, IField<T>
    {
        private readonly IField<T> _value;

        public AutoNotifyingField() : this(new Field<T>()) { }

        public AutoNotifyingField(IField<T> value)
        {
            _value = value;
        }

        public T Value
        {
            get { return _value.Value; }
            set
            {
                _value.Value = value;
                NotifyOfPropertyChange(() => Value);
            }
        }
    }
}
