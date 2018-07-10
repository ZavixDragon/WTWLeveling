namespace ExtendHealth.Ssc.AuthRep.Fields
{
    public class Field<T> : IField<T>
    {
        public T Value { get; set; }

        public Field() : this(default(T)) { }

        public Field(T value)
        {
            Value = value;
        }
    }
}
