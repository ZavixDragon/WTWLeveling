using System;
using System.Windows.Input;
using ExtendHealth.Ssc.Framework;
using ExtendHealth.Ssc.Model.Validation;

namespace ExtendHealth.Ssc.AuthRep.Fields
{
    public class ValidatedField<T> : NotifyPropertyChangedBase, IField<T>
    {
        private readonly IField<T> _value;
        private readonly Func<T, ValidationResult> _validate;
        private bool _shouldValidate = false;

        public ValidationResult Validation => _shouldValidate ? _validate(Value) : new ValidationResult();
        public ICommand ValidateCommand => new Command(InitValidation);

        public ValidatedField(Func<T, ValidationResult> validate) : this(new Field<T>(), validate) { }

        public ValidatedField(IField<T> value, Func<T, ValidationResult> validate)
        {
            _value = value;
            _validate = validate;
        }

        public T Value
        {
            get { return _value.Value; }
            set
            {
                _value.Value = value;
                NotifyOfPropertyChange(() => Validation);
            }
        }

        public void InitValidation()
        {
            _shouldValidate = true;
            NotifyOfPropertyChange(() => Validation);
        }
    }
}
