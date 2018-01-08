using Xunit;

namespace Leveling.StandardLanguageKeywords
{
    //These are all access modifiers they declare who is allowed to use these things
    public class PublicPrivateProtected
    {
        public string PublicName => "PublicPrivateProtected";
        protected string ProtectedName => "bob";
    }

    public class PublicTests
    {
        [Fact]
        public void CanAccessPublicsFreely()
        {
            Assert.NotNull(new PublicPrivateProtected().PublicName);
        }
    }

    public class ProtectedTests : PublicPrivateProtected
    {
        [Fact]
        public void InheritersCanAccessProtectedsFreely()
        {
            Assert.NotNull(ProtectedName);
        }

        [Fact]
        public void CanAccessProtectedsFromOtherCopiesOfTheProtectedType()
        {
            Assert.NotNull(new ProtectedTests().ProtectedName);
            //Interestingly enough it cannot access this protectedName if it has another copy of the type, only if it's identical to this one
        }
    }

    public class PrivateTests
    {
        private string TestsName => "secret";

        [Fact]
        public void CanAccessPrivateVariablesInternally()
        {
            Assert.NotNull(TestsName);
        }

        [Fact]
        public void CanAccessPrivateVariablesOfOtherCopiesOfTheSameType()
        {
            Assert.NotNull(new PrivateTests().TestsName);
        }
    }
}
