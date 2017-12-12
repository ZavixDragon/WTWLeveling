namespace Leveling
{
    public class AnonymousTypes
    {
        //there are 2 anonymous types objects and dynamic

        //here is how you would have an anonymous object
        public object ImLazyAndDidNotBuildAClass()
        {
            //personally the only use for these that i know of is in linq statements when you read in data from a database as an intermediator to end up being combined into proper classes or structs 
            return new { readonlyProperty = 3 };
        }
        //there is a section on dynamic later that covers dynamics
    }
}
