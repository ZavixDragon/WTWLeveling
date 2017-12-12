namespace Leveling.GenericsAdvanced
{
    public class TypeInference
    {
        public TypeInference()
        {
            //First up type inference is used when passing in an arguement that is generic it now can tell what the reset of the Ts are
            var text = Transform("text");
            //Now the type will still be "string" because it was able to infer that the type returned would be string because the type passed in was a string
            //furthermore this also examplifies the second form of type inference which is "var" var doesn't what type it will be holding until its given the thing then it infers its type
        }

        public T Transform<T>(T thing)
        {
            return thing;
        }
    }
}
