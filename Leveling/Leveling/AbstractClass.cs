namespace Leveling
{
    //this cannot be created only its inheriters can be created just like an interface
    public abstract class AbstractClass
    {
        //this is just like an interface
        public abstract string Property { get; }

        //so is this
        public abstract string Method();

        //This is a method that gets to have functionality the will be applied in most cases and saves you the work of implementing in each inheriter
        public virtual string DefaultMethodGetCleanProperty()
        {
            return Property.Trim();
        }

        //this gives you a convenience function to be used by inheriters rather than implementing in privately in each inheriter
        protected int ValueOfProperty()
        {
            return Property.Length;
        }
    }

    public class Inheriter : AbstractClass
    {
        //this is where we have to provide the abstract functionality
        public override string Property => "something or another";

        public override string Method()
        {
            //here the protected method is being used that an interface cant provide
            return ValueOfProperty().ToString();
        }
    }

    public class SpecializedInheriter : AbstractClass
    {
        //clearly we can no longer call trim on this, so we better override that default method in this one case
        public override string Property => null;

        public override string Method()
        {
            return Property;
        }

        //here for just this class we go ahead and override that virtual method
        public override string DefaultMethodGetCleanProperty()
        {
            return "";
        }
    }
}
