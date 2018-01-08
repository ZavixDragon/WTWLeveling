using Xunit;

namespace Leveling.StandardLanguageKeywords
{
    public class Params
    {
        //This is a sweet convience keyword that you must put as the last argument
        public Params(int num, params string[] args) {}
    }

    public class WithoutParams
    {
        public WithoutParams(int num, string[] args) {}
    }

    public class ParamsTests
    {
        [Fact]
        public void ExampleInitializations()
        {
            new WithoutParams(3, new[] {"pizza", "coffee", "donuts"});
            //Here it can tell all the args that come after the last non params args are part of the array that makes up the params
            new Params(3, "pizza", "coffee", "donuts");
        }
    }
}
