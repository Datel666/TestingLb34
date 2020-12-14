using NUnit.Framework;
using SemVer;
using System.Linq;

namespace TestingLb34
{
    class VersionParserTest
    {
        [Test]
        public void ParseMajorVersion1()
        {
            var version = new Version("1.2.3");
            Assert.AreEqual(version.Major, 1);
        }

        [Test]
        public void ParseMajorVersion2()
        {
            var version = new Version(" 1.2.3 ");
            Assert.AreEqual(version.Major, 1);
        }

        [Test]
        public void ParseMajorVersion3()
        {
            var version = new Version(" 2.2.3-4 ");
            Assert.AreEqual(version.Major, 2);
        }

        [Test]
        public void ParseMajorVersion4()
        {
            var version = new Version(" 3.2.3-pre ");
            Assert.AreEqual(version.Major, 3);
        }

        [Test]
        public void ParseMinorVersion1()
        {
            var version = new Version("1.2.3");
            Assert.AreEqual(version.Minor, 2);
        }

        [Test]
        public void ParseMinorVersion2()
        {
            var version = new Version(" 1.2.3 ");
            Assert.AreEqual(version.Minor, 2);
        }

        [Test]
        public void ParseMinorVersion3()
        {
            var version = new Version(" 2.2.3-4 ");
            Assert.AreEqual(version.Minor, 2);
        }

        [Test]
        public void ParseMinorVersion4()
        {
            var version = new Version(" 3.2.3-pre ");
            Assert.AreEqual(version.Minor, 2);
        }

        [Test]
        public void ParsePatchVersion1()
        {
            var version = new Version("1.2.3");
            Assert.AreEqual(version.Patch, 3);
        }

        [Test]
        public void ParsePatchVersion2()
        {
            var version = new Version(" 1.2.3 ");
            Assert.AreEqual(version.Patch, 3);
        }

        [Test]
        public void ParsePatchVersion3()
        {
            var version = new Version(" 2.2.3-4 ");
            Assert.AreEqual(version.Patch, 3);
        }

        [Test]
        public void ParsePatchVersion4()
        {
            var version = new Version(" 3.2.3-pre ");
            Assert.AreEqual(version.Patch, 3);
        }

    }
}
