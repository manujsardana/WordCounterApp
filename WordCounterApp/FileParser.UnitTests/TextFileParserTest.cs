using System;
using NUnit.Framework;
using FileParser;
using System.IO;
using Moq;
using System.IO.Abstractions;

namespace FileParser.UnitTests
{
    [TestFixture]
    public class TextFileParserTest
    {
        private IFileParser fileParser;
        private Mock<IFileSystem> mockFileSystem;

        [SetUp]
        public void SetUp()
        {
            mockFileSystem = new Mock<IFileSystem>();
            fileParser = new TextFileParser(mockFileSystem.Object);
        }

        [Test]
        public void ParseFileTest_FileFormatException()
        {
            Assert.Throws<FileFormatException>(() => { fileParser.ParseFile(@"TestFile.doc"); });
        }

        [Test]
        public void ParseFileTest_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { fileParser.ParseFile(string.Empty); });
        }

        [Test]
        public void ParseFileTest_FileNotFoundException()
        {
            mockFileSystem.Setup(x => x.File.Exists(It.IsAny<string>())).Returns(false);
            Assert.Throws<FileNotFoundException>(() => { fileParser.ParseFile(@"Y:\SampleNotExistsFile.txt"); });
        }

        [Test]
        public void ParseFileTest_EmptyFile()
        {
            mockFileSystem.Setup(x => x.File.Exists(It.IsAny<string>())).Returns(true);
            mockFileSystem.Setup(x => x.File.ReadAllText(It.IsAny<string>())).Returns(string.Empty);
            Assert.Throws<ArgumentException>(() => { fileParser.ParseFile(@"Y:\EmptyFile.txt"); });
        }

        [Test]
        public void ParseFileTest_FileWithText()
        {
            string inputText = "Unit Test Cases Test";
            mockFileSystem.Setup(x => x.File.Exists(It.IsAny<string>())).Returns(true);
            mockFileSystem.Setup(x => x.File.ReadAllText(It.IsAny<string>())).Returns(inputText);
            var outputText = fileParser.ParseFile(@"FileWithValidText.txt");
            Assert.AreEqual(outputText, inputText);
        }
    }
}
