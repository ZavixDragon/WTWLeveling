using System.Numerics;

namespace Leveling
{
    public class MethodOverloading
    {
        //these two methods are the correct way to use overloading they make things convenient
        public void Method(float x, float y, float z)
        {
            Method(new Vector3(x, y, z));
        }

        public void Method(Vector3 vector)
        {
            //do the things
        }


        //here is the exetremely bad way to use overloading
        public void Method2(string poetry)
        {
            //writes the poetry to the english database
        }

        //clear violation of single responsibility principle and will confuse the other devs
        public void Method2(double mathAnswer)
        {
            //writes to the math database
        }
    }
}
