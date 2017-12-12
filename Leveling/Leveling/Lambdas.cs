using System;

namespace Leveling
{
    //The greatest thing since sliced bread I present lambdas "args => actions" 
    public class Lambdas
    {
        public string CheckThisOut => "<< that's a lambda, its replacing the get syntax";

        public Lambdas() : this(() => "<< This is another lambda, it's replacing the old delegate syntax") {}

        public Lambdas(Func<string> doSomething) {}
    }
}
