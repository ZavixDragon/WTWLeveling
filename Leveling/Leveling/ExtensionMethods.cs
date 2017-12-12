using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Leveling
{
    public class ExtensionMethods
    {
        public bool IsValid { get; set; }
    }

    public interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
    }

    public class Bob : IPerson
    {
        public string FirstName => "Bob";
        public string LastName => "Bobson";
    }

    public static class Demonstrations
    {
        //First up when you want to add functionallity to a class you cant touch take list for example
        //it also lets you add functionality to specfic generic types rather than all of them
        public static IEnumerable<ExtensionMethods> Valids(this IEnumerable<ExtensionMethods> list)
        {
            return list.Where(x => x.IsValid);
        }

        //Another thing it is useful for, is when you have an interface and you want to give people a default method on that interface 
        public static string GetFullName(this IPerson person)
        {
            return $"{person.FirstName} {person.LastName}";
        }
    }

    public class ExtensionMethodsTests
    {
        [Fact]
        public void Valids_OnlyReturnsValidOnes()
        {
            var list = new List<ExtensionMethods>
            {
                new ExtensionMethods { IsValid = true },
                new ExtensionMethods { IsValid = false }
            };

            //this is where it gets fun, the extension method will appear as if it is a method on the actual object itself
            var validList = list.Valids().ToList();

            Assert.Equal(1, validList.Count);
        }

        [Fact]
        public void GetFullName_FirstNameAndLastNamePresent()
        {
            var bob = new Bob();

            //As you can see because bob is an IPerson it gains the functionality of that extension method
            var fullName = bob.GetFullName();

            Assert.True(fullName.Contains(bob.FirstName) && fullName.Contains(bob.LastName));
        }
    }
}
