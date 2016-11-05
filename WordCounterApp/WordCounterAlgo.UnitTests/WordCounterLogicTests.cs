using System;
using NUnit.Framework;
using Moq;
using System.Linq;

namespace WordCounterAlgo.UnitTests
{
    [TestFixture]
    public class WordCounterLogicTests
    {
        private IWordCounter wordCounter;

        [SetUp]
        public void SetUp()
        {
            wordCounter = new WordCounterLogic();
        }

        [Test]
        [TestCase("Go do that thing that you do so well")]
        public void CountWordTestCaseOne(string inputString)
        {
            var output = wordCounter.CountWord(inputString);
            Assert.IsTrue(output != null && output.Count() > 0);
            Assert.IsTrue(output.Count() == 7);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("Go")).First().WordCount == 1);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("do")).First().WordCount == 2);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("that")).First().WordCount == 2);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("thing")).First().WordCount == 1);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("you")).First().WordCount == 1);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("so")).First().WordCount == 1);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("well")).First().WordCount == 1);
        }

        [Test]
        [TestCase("This is the text in the Unit test case")]
        public void CountWordTestCaseTwo(string inputString)
        {
            var output = wordCounter.CountWord(inputString);
            Assert.IsTrue(output != null && output.Count() > 0);
            Assert.IsTrue(output.Count() == 8);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("This")).First().WordCount == 1);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("is")).First().WordCount == 1);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("the")).First().WordCount == 2);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("text")).First().WordCount == 1);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("in")).First().WordCount == 1);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("Unit")).First().WordCount == 1);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("test")).First().WordCount == 1);
            Assert.IsTrue(output.Where(x => x.WordString.Equals("case")).First().WordCount == 1);
        }

        [Test]
        [TestCase("")]
        public void CountWordTestCaseThreeEmptyText(string inputString)
        {
            var output = wordCounter.CountWord(inputString);
            Assert.IsTrue(output != null && output.Count() == 0);
        }
    }
}
