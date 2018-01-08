namespace Leveling.StandardLanguageKeywords
{
    public class ReadonlyConst
    {
        //readonly variables cannot be changed after an object's creation
        private readonly string _value = "a text value";

        //readonly variables don't have to be determined until you create them
        private readonly string _toBeDetermined;

        //Const variables must be in the variables initializer and cannot change
        //Const variables are compiled differently then readonly variables making them more performant
        //Const can only be the among the types; numbers, bools, strings, and null.
        private const string LockedIn = "I cannot change";

        public ReadonlyConst(string determing)
        {
            //Here is the one assignment to this readonly variable
            _toBeDetermined = determing;
        }
    }
}
