using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using MagicFilesLib;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        private Mock<IDirectoryExplorer> _mockDirExplorer;

        [OneTimeSetUp]
        public void Init()
        {
            _mockDirExplorer = new Mock<IDirectoryExplorer>();
            _mockDirExplorer.Setup(de => de.GetFiles(It.IsAny<string>()))
                .Returns(new List<string> { _file1, _file2 });
        }

        [Test]
        public void TestFileRetrieval()
        {
            var result = _mockDirExplorer.Object.GetFiles("dummyPath");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            CollectionAssert.Contains(result, _file1);
        }
    }
}
