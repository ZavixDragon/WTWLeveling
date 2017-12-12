using Xunit;

namespace Leveling
{
    public struct Struct
    {
        public string StructName;
    }

    public class Class
    {
        public string ClassName;
    }

    public class StructTests
    {
        //These tests demonstrate the primary differences between structs and classes
        [Fact]
        public void WhenComparingStructsForEquality_WhenTheyHaveTheSameValue_TheyAreEqual()
        {
            var struct1 = new Struct { StructName = "bob" };
            var struct2 = new Struct { StructName = "bob" };

            Assert.Equal(struct1, struct2);
        }

        [Fact]
        public void WhenComparingClassesForEquality_WhenTheyHaveTheSameValue_TheyAreNotEqual()
        {
            var class1 = new Class { ClassName = "dragon" };
            var class2 = new Class { ClassName = "dragon" };

            Assert.NotEqual(class1, class2);
        }

        [Fact]
        public void WhenChangingAValueOnAStruct_ReferencesAreBroken()
        {
            var struct1 = new Struct { StructName = "snake" };
            var originalStruct = struct1;

            struct1.StructName = "owl";

            Assert.NotEqual(originalStruct.StructName, struct1.StructName);
        }

        [Fact]
        public void WhenChangingAValueOnAClass_ReferencesRemainInTact()
        {
            var class1 = new Class { ClassName = "airplane" };
            var originalClass = class1;

            class1.ClassName = "lazer";

            Assert.Equal(class1.ClassName, originalClass.ClassName);
        }

        //the other difference thats worth noting since they are almost entirely by value they are placed on the stack instead of the heap and they skip the normal things involved in class creation, so they are more performant
    }
}
