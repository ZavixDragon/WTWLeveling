using Xunit;

namespace Leveling
{
    //a bit wise operation takes whatever number you throw at it converts it to binary and then acts on it
    public class BitwiseOperations
    {
        //The and operator compares each binary number and if both of them are 1 then it keeps the 1 otherwise it becomes 0
        [Fact]
        public void AndOperator()
        {
            Assert.Equal(0x0, 0x0 & 0x0);
            Assert.Equal(0x0, 0x1 & 0x0);
            Assert.Equal(0x1, 0x1 & 0x1);
            Assert.Equal(0x0, 0x10 & 0x1);
            //normally you want to avoid doing bitwise operations on signed ints as that can have unintended consequences but you should now how it works
            Assert.Equal(1, 1 & 1);
            //The negative is stored as a 1 in front of the binary number
            Assert.Equal(1, -1 & 1);
            Assert.Equal(-1, -1 & -1);

            Assert.Equal(0x8119, 0x9999 & 0xC37F);
        }

        //The exclusive or operator compares each binary number and if they dont match it gives a 1 otherwise it gives a 0
        [Fact]
        public void ExclusiveOrOperator()
        {
            Assert.Equal(0x0, 0x0 ^ 0x0);
            Assert.Equal(0x1, 0x1 ^ 0x0);
            Assert.Equal(0x0, 0x1 ^ 0x1);
            Assert.Equal(0x11, 0x10 ^ 0x1);
            Assert.Equal(0, 1 ^ 1);
            //There is some weirdness whenever you do a bitwise operation that ends up zero with a negative signature then it is interpretted as -2
            Assert.Equal(-2, -1 ^ 1);
            Assert.Equal(0, -1 ^ -1);

            Assert.Equal(0x5AE6, 0x9999 ^ 0xC37F);
        }

        //The inclusive or operator compares each binary number if either side has a 1 then it gives a 1 otherwise it gives a 0
        [Fact]
        public void InclusiveOr()
        {
            Assert.Equal(0x0, 0x0 | 0x0);
            Assert.Equal(0x1, 0x1 | 0x0);
            Assert.Equal(0x1, 0x1 | 0x1);
            Assert.Equal(0x11, 0x10 | 0x1);
            Assert.Equal(1, 1 | 1);
            Assert.Equal(-1, -1 | 1);
            Assert.Equal(-1, -1 | -1);

            Assert.Equal(0xDBFF, 0x9999 | 0xC37F);
        }
    }
}
