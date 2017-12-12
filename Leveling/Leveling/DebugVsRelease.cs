using Xunit;

namespace Leveling
{
    //Most importnatly Debug buidls come with a special pdb file and compile in such a way that a debugger can be attached to them
    //Release builds in addition to not being debuggable and not generating a pdb file they also cut what the think are unused variables. This makes release builds smaller.
    public class DebugVsRelease
    {
        //last but not least compiler symbols when you want to have differences between debug and release
        [Fact]
        public void ShouldBeInDebug()
        {
            bool isInDebug;
#if DEBUG
            isInDebug = true;
#endif
#if RELEASE
            isInDebug = false;
#endif
            Assert.True(isInDebug);
        }
    }
}
