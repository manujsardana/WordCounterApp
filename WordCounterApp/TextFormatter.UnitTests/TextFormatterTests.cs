using System;
using NUnit.Framework;
using Moq;
using System.Linq;
using DataModel;
using System.Collections;
using System.Collections.Generic;

namespace TextFormatter.UnitTests
{
    [TestFixture]
    public class TextFormatterTests
    {
        private ITextFormatter textFormatter;

        [SetUp]
        public void Setup()
        {
            textFormatter = new TextFormatter();
        }

        [Test]
        [TestCaseSource("TestCaseGeneratorOne")]
        public void FormatTextTestCaseOne(List<Word> input)
        {
            var output = textFormatter.FormatText(input);
            Assert.IsTrue(output.StartsWith("1:Go"));
            Assert.IsTrue(output.Contains("2:do\r\n"));
            Assert.IsTrue(output.Contains("2:that\r\n"));
            Assert.IsTrue(output.Contains("1:thing\r\n"));
            Assert.IsTrue(output.Contains("1:you\r\n"));
            Assert.IsTrue(output.Contains("1:so\r\n"));
            Assert.IsTrue(output.EndsWith("1:well\r\n"));
            Assert.AreEqual(output.Count(), 50);
        }

        [Test]
        [TestCaseSource("TestCaseGeneratorTwo")]
        public void FormatTextTestCaseTwo(List<Word> input)
        {
            var output = textFormatter.FormatText(input);
            Assert.IsTrue(output.StartsWith("1:This"));
            Assert.IsTrue(output.Contains("1:is\r\n"));
            Assert.IsTrue(output.Contains("2:the\r\n"));
            Assert.IsTrue(output.Contains("1:text\r\n"));
            Assert.IsTrue(output.Contains("1:in\r\n"));
            Assert.IsTrue(output.Contains("1:Unit\r\n"));
            Assert.IsTrue(output.Contains("1:test\r\n"));
            Assert.IsTrue(output.EndsWith("1:case\r\n"));
            Assert.AreEqual(output.Count(), 59);
        }
        static IEnumerable<IEnumerable<Word>> TestCaseGeneratorOne = new List<IEnumerable<Word>>
            {
                new List<Word>
                {
                    new Word { WordString = "Go", WordCount = 1 },
                    new Word { WordString = "do", WordCount = 2 },
                    new Word { WordString = "that", WordCount = 2 },
                    new Word { WordString = "thing", WordCount = 1 },
                    new Word { WordString = "you", WordCount = 1 },
                    new Word { WordString = "so", WordCount = 1 },
                    new Word { WordString = "well", WordCount = 1 }
                }
            };

        static IEnumerable<IEnumerable<Word>> TestCaseGeneratorTwo = new List<IEnumerable<Word>>
            {
                new List<Word>
                {
                    new Word { WordString = "This", WordCount = 1 },
                    new Word { WordString = "is", WordCount = 1 },
                    new Word { WordString = "the", WordCount = 2 },
                    new Word { WordString = "text", WordCount = 1 },
                    new Word { WordString = "in", WordCount = 1 },
                    new Word { WordString = "Unit", WordCount = 1 },
                    new Word { WordString = "test", WordCount = 1 },
                    new Word { WordString = "case", WordCount = 1 },
                }
            };
    }
}
