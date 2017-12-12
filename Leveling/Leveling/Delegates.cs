using System;
using Xunit;

namespace Leveling
{
    //delegates are the best need to delegate some work to another class well no worries 
    public class Delegates
    {
        //here you can also require custom delegate you invented
        public Delegates(Transaction customDelegate)
            : this(() => { customDelegate("this requires a string"); }) {}

        //one form of delegate is a func short for function this kind of delegate returns something
        public Delegates(Func<string> delegateFunc) 
            //one way to create an action or function is with this sweet lambda syntax 
            : this(() => { delegateFunc(); }) {}

        //one form of delegate is action it is a bit of code that can be excuted at a later time by whoever has the action, it cannot return anything
        public Delegates(Action delegateAction)
        {
            //invoking delegates is also fun they get invoked as if they were methods
            delegateAction();
        }
    }

    //check it out you can make restricted delegate if you want
    public delegate int Transaction(string parameter);

    public class DelegatesTest
    {
        [Fact]
        public void ThrowException_StackTraceContainsTheClass()
        {
            try
            {
                new Delegates(() => throw new Exception());
            }
            catch (Exception ex)
            {
                //As you can see it includes whoever fired off the delegate in the stacktrace
                Assert.Contains("Delegates.", ex.StackTrace);
            }
        }

        [Fact]
        public void DelegateCanAffectSomethingInAnotherScope()
        {
            var succeeded = false;

            //just to show you the old way of constructing these delegates
            new Delegates(delegate { succeeded = true; });

            Assert.True(succeeded);
        }

        //Sometimes Func does not reveal what its doing and you want to use a more revealing type name for your delegate
        [Fact]
        public void CustomDelegate()
        {
            var succeeded = false;

            //here its smart enough to infer your using a transaction as its more specific then Func<int, T>
            new Delegates((parameter) =>
            {
                succeeded = true;
                return 1;
            });

            //sometimes you might have competeing delegates here is how you specifically specify which delegate you want to use
            new Delegates(new Transaction((parameter) => 1));

            Assert.True(succeeded);
        }
    }
}
