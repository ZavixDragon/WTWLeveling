using System;
using Xunit;

namespace Leveling.StandardLanguageKeywords
{
    //This awesome keyword shortens the syntax of disposing things 
    public class RiskyDisposable : IDisposable
    {
        public bool IsDisposed { get; private set; } = false;

        public RiskyDisposable() {}

        public RiskyDisposable(string arg) {}

        public string RiskyMethod()
        {
            throw new Exception();
        }

        public void NonRiskyMethod() {}

        public void Dispose()
        {
            IsDisposed = true;
        }
    }

    public class UsingTests
    {
        [Fact]
        public void CallRiskyDisposableWithoutProtection_NotDisposed()
        {
            //Before if an exception was thrown things might not be cleaned up if you were not being careful
            var disposable = new RiskyDisposable();

            try
            {
                disposable.RiskyMethod();
                disposable.Dispose();
            }
            catch
            {
            }

            Assert.False(disposable.IsDisposed);
        }

        [Fact]
        public void CallRiskyDisposableTheOldSafeWay_Disposed()
        {
            //People solved a way to do it safely though you just had to write a few lines
            var disposable = new RiskyDisposable();

            try
            {
                disposable.RiskyMethod();
            }
            catch
            {
            }
            finally
            {
                disposable.Dispose();
            }

            Assert.True(disposable.IsDisposed);
        }

        [Fact]
        public void CallRiskyWithinCallRiskys_ThisJustGotUgly()
        {
            //Sometimes people found they needed the result of one risky operation to create an object for another risky operation
            var disposable = new RiskyDisposable();
            RiskyDisposable soonToBeCreatedDisposable = null;

            try
            {
                var result = disposable.RiskyMethod();
                soonToBeCreatedDisposable = new RiskyDisposable(result);
                soonToBeCreatedDisposable.RiskyMethod();
            }
            catch
            {
            }
            finally
            {
                disposable.Dispose();
                //thanks to null propogation we no longer need the if statement asking if it's null lol
                soonToBeCreatedDisposable?.Dispose();
            }

            Assert.True(disposable.IsDisposed);
            if (soonToBeCreatedDisposable != null)
                Assert.True(soonToBeCreatedDisposable.IsDisposed);
        }

        [Fact]
        public void BeholdUsingInPlaceOfFinallies()
        {
            RiskyDisposable disposable = null;
            RiskyDisposable soonToBeCreatedDisposable = null;

            try
            {
                //now even if these throw exceptions they will still dispose no more finallies
                using (disposable = new RiskyDisposable())
                    using (soonToBeCreatedDisposable = new RiskyDisposable(disposable.RiskyMethod()))
                        soonToBeCreatedDisposable.RiskyMethod();
            }
            catch
            {
            }

            if (disposable != null)
                Assert.True(disposable.IsDisposed);
            if (soonToBeCreatedDisposable != null)
                Assert.True(soonToBeCreatedDisposable.IsDisposed);
        }

        [Fact]
        public void AlsoUsingsLookPrettierWhenDoingNonRiskyThings()
        {
            using (var disposable = new RiskyDisposable())
                disposable.NonRiskyMethod();

            //vs 

            var disposable2 = new RiskyDisposable();
            disposable2.NonRiskyMethod();
            disposable2.Dispose();
        }
    }

}
