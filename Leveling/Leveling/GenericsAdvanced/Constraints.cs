using System;
using System.Collections.Generic;

namespace Leveling.GenericsAdvanced
{
    //here is an excellent example that ensures that the type used has an empty constructor (especially useful for serialization)
    public class Constraints<T> where T : new() {}

    //Sometimes you gotta ensure that it fills multiple interfaces like so
    public class SecondExample<T> where T : IDisposable, IComparable {}

    //Maybe you need it to be a struct
    public class ThirdExample<T> where T : struct {}

    //actually you know what I like references better make it by class
    public class FourthExample<T> where T : class {}

    //I need 2 types but one of those types has to either be, or implement, or derive from the second
    public class FifthExample<T, T2> where T : T2 {}

    //Lastly and absolutely the least common one, because the only reason you would ever use this one is to combine it with other constraits, otherwise you would just use the type
    public class SixthExample<T> where T : List<string> {}
}
