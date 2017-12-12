using System;

namespace Leveling
{
    public class PropertiesVsFields
    {
        //fields are more performant then properties
        public string Field; 

        //both fields and properties can be readonly
        public readonly string ReadonlyField;
        public string ReadonlyProperty { get; }

        //But only properties can expose just reading to the public but stay mutable
        public string OnlyPubliclyGettable { get; private set; }

        //Auto-Properties are almost equivalent to this
        public string AutoProperty { get; set; }
        //is almost equivalent to
        private string _manualProperty;

        public string ManualProperty
        {
            //You are allowed to define the way the value is retrieved
            //and any other things you may want to do while retrieving the value
            get { return _manualProperty; }
            //the setter also has the new proposed value come in through the "value" and you can also write custom logic here as well
            set { _manualProperty = value; }
        }

        //Lambda Properties like this
        public string LambdaProperty => "here you go";
        //are equivalent to
        public string NonLambdaProperty { get { return "here you go"; } }

        //as you can see properties are much more versatile in what they are capable of
        //but fields ensure fine control and performance

        //calculation property example
        public string FirstName;
        public string LastName;
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
