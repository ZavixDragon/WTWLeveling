using Xunit;

namespace Leveling
{
    public class StringInterpolation
    {
        public string CheckOutStringInterpolation(string adjective)
        {
            return $"this is {adjective}";
        }

        [Fact]
        public void CheckOutStringInterPolation_InsertsAdjectiveCorrectly()
        {
            Assert.Equal("this is awesome!", CheckOutStringInterpolation("awesome!"));
        }
    }
}
