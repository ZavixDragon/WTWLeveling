using Xunit;

namespace Leveling
{
    public class StaticVsNonStatic
    {
        //static variables are actually kept at the global namespace using the class name as just extra routing. so anything done with it has global impact
        public static int StaticIndex { get; set; } = 0;
        public int NonStaticIndex { get; set; } = 0;

        public int GetStaticIndex()
        {
            return StaticIndex;
        }
    }

    public static class StaticallyGroupedStuff
    {
        //you cant have non statics in a static class
        public static void GoodOldQuestionableUtilMethod() {}
    }

    //just for fun ill show you where a private static method in a non-static class might be useful
    public class SampleFileClass
    {
        private static object _lock = new object();

        private static void Write()
        {
            lock (_lock)
            {
                //do the writing to the file here
            }   
        }

        private static string Read()
        {
            lock (_lock)
            {
                return ""; //do the reading here
            }
        }

        //now this will ensure even though you might have a bunch of these instances floating around all of them wont try to read and write from the file they represent at the same time
    }

    public class StaticVsNonStaticTests
    {
        [Fact]
        public void WhenYouAddToStaticInt_AllReferencesEffected()
        {
            var intHolder = new StaticVsNonStatic();

            StaticVsNonStatic.StaticIndex++;

            Assert.Equal(1, intHolder.GetStaticIndex());
        }

        [Fact]
        public void WhenYouAddToNonStaticInt_OnlyEffectsThatInstance()
        {
            var intHolder1 = new StaticVsNonStatic();
            var intHolder2 = new StaticVsNonStatic();

            intHolder1.NonStaticIndex++;

            Assert.NotEqual(intHolder1.NonStaticIndex, intHolder2.NonStaticIndex);
        }
    }
}
