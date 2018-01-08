using Xunit;

namespace Leveling.StandardLanguageKeywords
{
    public class Ref
    {
        //Here we specify that the int must keep it's reference, this is used to indicate destructive changes are either happening to the variable or if its a threaded object that it can change while you are using it (this would generally be considered a bad practice)
        public void IncrementByRef(ref int num)
        {
            num++;
        }
    }

    public class RefTests
    {
        [Fact]
        public void IncrementByRef_IntKeepsChange()
        {
            var i = 0;
            new Ref().IncrementByRef(ref i);
            //Even though normally if you pass a struct in and it under goes a modification the reference is broken but in this case we explicitly said keep the reference intact
            Assert.Equal(1, i);
        }
    }
}
