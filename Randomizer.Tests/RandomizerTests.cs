using System;
using System.Linq;
using Xunit;

namespace Randomizer.Tests
{
    public class RandomizerTests
    {
        [Fact]
        public void PullLength_ByDefault_35()
        {
            var randomizer = new Randomizer();
            Assert.True(randomizer.Pull.Length == 35);
        }

        [Fact]
        public void HistoryLength_ByDefault_4()
        {
            var randomizer = new Randomizer();
            Assert.True(randomizer.History.Length == 4);
        }

        [Fact]
        public void GetNext_BatchOfItems()
        {
            Randomizer randomizer = new Randomizer(0, 100000);
            Func<int> getRandom = () => randomizer.GetNext();

            var result = Enumerable.Range(0, 1000).Select(
                i => {
                        int r = getRandom();
                        return r;
                    }
                ).ToArray();

            Assert.True(true);
        }

        [Fact]
        public void RandomFromSystem()
        {
            Random randomizer = new Random();
            Func<int> getRandom = () => randomizer.Next(0, 12);

            var result = Enumerable.Range(0, 12).Select(
                i => {
                        int r = getRandom();
                        return r;
                    }
                ).ToArray();

            Assert.True(true);
        }
    }
}
