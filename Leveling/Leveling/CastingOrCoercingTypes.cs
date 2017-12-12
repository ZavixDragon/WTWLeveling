using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Xunit;

namespace Leveling
{
    public class CastingOrCoercingTypes
    {
        public string GetThing(object obj)
        {
            //First up when you know that what you just got passed is something else and you want to access something in it, you can cast it like so
            return ((SpecificType) obj).Thing;
        }

        public void IncrementAll(List<GeneralType> generals)
        {
            generals.ForEach(x => x.Index++);
        }

        public GeneralType Increment(GeneralType general)
        {
            general.Index++;
            return general;
        }

        //This is the way that you should NOT use casting
        public void TrashIncrementMethod(object thing)
        {
            if (thing is GeneralType)
                ((GeneralType) thing).Index++;
            if (thing is List<GeneralType>)
                ((List<GeneralType>) thing).ForEach(x => x.Index++);
            //If you are sensing a bad contract and a violation of single responsibility principle and a threat on open close principle, then you might just right.
        }
    }

    public class SpecificType : GeneralType
    {
        public string Thing => "thing";
    }

    public class GeneralType
    {
        public int Index { get; set; } = 0;

        //So you want to make something coercable to another type do you?
        public static implicit operator int(GeneralType general)
        {
            return general.Index;
        }

        //or maybe you want to be able to coerce a different type into this type
        public static implicit operator GeneralType(int index)
        {
            return new GeneralType { Index = index };
        }
    }

    public class CastingOrCoercingTests
    {
        [Fact]
        public void CastingToMoreSpecificExample()
        {
            var something = new SpecificType();

            //Here is an example of implicit conversion, since it wants an object a SpecificType is being coerced to be an object
            var thing = new CastingOrCoercingTypes().GetThing(something);

            Assert.Equal(something.Thing, thing);
        }

        [Fact]
        public void CastingToGeneralTypeToCallMethodExample()
        {
            var things = new List<SpecificType> {new SpecificType(), new SpecificType()};

            //Here you see that we have to cast to a more generic type because the type is within a generic
            new CastingOrCoercingTypes().IncrementAll(things.Cast<GeneralType>().ToList());

            Assert.True(things.All(x => x.Index == 1));
        }

        [Fact]
        public void OnePlusGeneral_EqualsTwo()
        {
            var general = new GeneralType { Index = 1 };

            //Look at how nicely implicit conversion makes this
            Assert.Equal(2, 1 + general);
        }

        [Fact]
        public void IncrementInt_GeneralReturned()
        {
            var number = 1;

            //Look at how easy that was to call the increment method and have coerced right into a general type
            var incrementedGeneral = new CastingOrCoercingTypes().Increment(number);

            Assert.Equal(typeof(GeneralType), incrementedGeneral.GetType());
        }
    }
}
