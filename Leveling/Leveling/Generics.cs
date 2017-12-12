namespace Leveling
{
    //here is an example of generic that might add bahaviour to something
    public class Generics<T>
    {
        private readonly T _obj;

        public Generics(T obj)
        {
            _obj = obj;
        }
    }
    //these are used very often in custom collections and in wrappers
}
