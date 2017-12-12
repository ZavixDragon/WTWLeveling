using System.Collections.Generic;

namespace Leveling.GenericsAdvanced
{
    //open types involve type parameters closed types are just types that are not open

    //this is a closed type
    public class OpenClosedTypes
    {
    }

    //here is an open type
    public class OpenClass<T>
    {
        //that parameter is indeed an openclass
        public OpenClass(T openClass)
        {
            //this is an open class too
            var list = new List<T>();
            //still an open class
            var array = new T[1];
            //even when its only partially open its still open
            var dictionary = new Dictionary<int, T>();
        }
    }
}
