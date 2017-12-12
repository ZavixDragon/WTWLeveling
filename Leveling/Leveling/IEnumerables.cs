using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Leveling
{
    //Ienumerables can be iterated over
    public class IEnumerables
    {

    }

    public class RepeatingList<T> : IEnumerable<T>
    {
        //lists and other kinds of collections are all enumerables but a lot of them are finite
        private readonly List<T> _finiteList;

        private bool _hasRepeated = false;
        private int _index = 0;

        public RepeatingList(List<T> finiteList)
        {
            _finiteList = finiteList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                if (_index >= _finiteList.Count && !_hasRepeated)
                {
                    _hasRepeated = true;
                    _index = 0;
                }
                if (_index >= _finiteList.Count && _hasRepeated)
                    //There are 2 ways to yield break, either to call yield break or to let it get to the end of the method will do a yield break
                    //yield break tells whoever is iterating that the list is finished
                    yield break;
                //the other really interesting thing about yield return is if you ask for the next number it will continue from the last yield return
                yield return _finiteList[_index];
                _index++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //A less common type of Ienumerable is a non finite one
    public class LoopingList<T> : IEnumerable<T>
    {
        private readonly List<T> _finiteList;

        private int _index = 0;

        public LoopingList(List<T> finiteList)
        {
            _finiteList = finiteList;
        }


        public IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                if (!_finiteList.Any())
                    yield break;
                if (_index >= _finiteList.Count)
                    _index = 0;
                yield return _finiteList[_index];
                _index++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //one last kind of enumerator that are awesome is generators
    public class RandomNumberGenerator : IEnumerable<int>
    {
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        public IEnumerator<int> GetEnumerator()
        {
            //the concept is simple you can make something that you can keep pulling values from until you want
            while (true)
                yield return _random.Next();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class IEnumerablesTests
    {
        [Fact]
        public void RepeatingList_EmptyList_YieldBreaksImmidiately()
        {
            var list = new RepeatingList<int>(new List<int>());

            //to list call will iterator through the ienumerable until it hits a yield break
            var newList = list.ToList();

            Assert.Equal(0, newList.Count);
        }

        [Fact]
        public void RepeatingList_IteratoringThroughIt_GoesThroughItTwice()
        {
            var list = new RepeatingList<int>(new List<int> { 1, 2, 3 });

            //Take will short circuit if a yield break happens during it
            var newList = list.Take(7).ToList();

            Assert.Equal(6, newList.Count);
            Assert.Equal(2, newList.Count(x => x == 1));
            Assert.Equal(2, newList.Count(x => x == 2));
            Assert.Equal(2, newList.Count(x => x == 3));
        }

        [Fact]
        public void RepeatingList_WhenOverExtendsTheUnderlyingEnumerator_ExceptionThrown()
        {
            var list = new LoopingList<int>(new List<int> { 1, 2, 3 });

            //another way you can test this is by using the underlying IEnumerator interface
            var enumerator = list.GetEnumerator();
            for (int i = 0; i < 7; i++)
                enumerator.MoveNext();
        }

        [Fact]
        public void LoopingList_EmptyList_YieldBreaksImmidiately()
        {
            var list = new LoopingList<int>(new List<int>());

            var newList = list.ToList();

            Assert.Equal(0, newList.Count);
        }

        [Fact]
        public void LoopingList_TakeTons_NeverYieldBreaks()
        {
            var list = new LoopingList<int>(new List<int> { 1, 2, 3 });

            //As mentioned previously take will short circuit if a yield break occurs
            var newList = list.Take(100).ToList();

            Assert.Equal(100, newList.Count);
            Assert.Contains(1, newList);
            Assert.Contains(2, newList);
            Assert.Contains(3, newList);
        }

        [Fact]
        public void LoopingList_UsingUnderlyingEnumerator_NeverThrowsException()
        {
            var list = new LoopingList<int>(new List<int> { 1, 2, 3 });

            //another way you can test this is by using the underlying IEnumerator interface
            var newList = new List<int>();
            var enumerator = list.GetEnumerator();
            for (int i = 0; i < 100; i++)
            {
                newList.Add(enumerator.Current);
                enumerator.MoveNext();
            }

            Assert.Equal(100, newList.Count);
        }
    }
}
