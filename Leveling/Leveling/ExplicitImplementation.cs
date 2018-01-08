using Xunit;

namespace Leveling
{
    //This is most commonly used when you are inheritting 2 interfaces that have a method or property that share a name
    public class ExplicitImplementation : ISimiliarInterface, ISimpleInterface
    {
        //You can specify which interface this method belongs to by listing the interface you are explicitly implementing 
        //when explicitly implimenting an interfaces method you don't specify the scope because it must be public
        string ISimiliarInterface.GetValue()
        {
            return "value";
        }

        //As you can see here you don't have to explicitly implement the interface if all other methods and properties have already been explicitly implemented
        public int GetValue()
        {
            return 1;
        }

        //This method implicitly implements both methods interfaces at the same time
        public string GetText()
        {
            return string.Empty;
        }

        string ISimpleInterface.GetName()
        {
            return "simple";
        }

        string ISimiliarInterface.GetName()
        {
            return "similiar";
        } 
    }

    public interface ISimpleInterface
    {
        string GetText();
        int GetValue();
        string GetName();
    }

    public interface ISimiliarInterface
    {
        string GetText();
        string GetValue();
        string GetName();
    }

    public class ExplicitImplementationTests
    {
        [Fact]
        public void WhenAskingForValue_ItChoosesToUseTheNonExplicitInterface()
        {
            var implementation = new ExplicitImplementation();

            Assert.Equal(1, implementation.GetValue());
            //Assert.Equal("value", implementation.GetValue());
        }

        [Fact]
        public void WhenUsedAsItsInterface_ItUsesTheExplicitImplementation()
        {
            ISimiliarInterface similiar = new ExplicitImplementation();

            Assert.Equal("value", similiar.GetValue());
        }

        [Fact]
        public void y()
        {
            var implementation = new ExplicitImplementation();

            //You cannot call the method if both are explictedly implemented unless you first clear up what type it's representing
            //Assert.Equal("simple", implementation.GetName());
            ISimpleInterface simple = implementation;
            ISimiliarInterface similiar = implementation;

            Assert.Equal("simple", simple.GetName());
            Assert.Equal("similiar", similiar.GetName());
        }
    }
}
