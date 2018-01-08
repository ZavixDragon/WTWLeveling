using Xunit;

namespace Leveling.StandardLanguageKeywords
{
    public class Default
    {
        //Defaults are commonly used with T as default solves the problem of not know what the default return would be
        public T GetDefault<T>(T thing)
        {
            return default(T);
        }
    }

    public enum EnumDefault
    {
        none, 
        something
    }

    //There currently is no way for a type to override the default keyword, but i hope in the future they add it so that way you can apply null object pattern to it

    public class DefaultTests
    {
        [Fact]
        public void DefaultOnAnObject_IsNull()
        {
            //the default of objects is null
            Assert.Null(new Default().GetDefault(new object()));
        }

        [Fact]
        public void DefaultOnStructs()
        {
            var defaulter = new Default();

            Assert.Equal(0, defaulter.GetDefault(3));
            Assert.Equal(false, defaulter.GetDefault(true));
            //The first entry in an enum is always the default one
            Assert.Equal(EnumDefault.none, defaulter.GetDefault(EnumDefault.something));
        }
    }
}
