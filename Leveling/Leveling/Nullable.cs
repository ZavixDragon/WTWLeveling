using System;

namespace Leveling
{
    //people clearly didn't break the language enough with null, so with this feature you can make structs and classes that normally can't be null null
    public class Nullable
    {
        public Nullable()
        {
            //the old syntax
            var schrodingersInt = new Nullable<int>();

            //the new syntax
            int? questionableInt = null;
        }
        //You are wondering when you would ever use this and the answer is when questionable data coming from outside your system might be null and you don't want to blow up
    }
}
