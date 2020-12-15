using NUnit.Framework;
using SemVer;
using System.Linq;

namespace TestingLb34
{
    // проверки наличия в интервале конкретной версии и другого интервала: bool contains(Version) bool contains(VersionRange)
    class TildaRangeContainsTest
    {
        [Test]
        public void TestTildaRangeContainVersion()
        {
            var range = new Range("~1.2.3");
            Assert.IsTrue(range.Contains("1.2.4"));
            Assert.IsTrue(range.Contains("1.2.9"));
            Assert.IsFalse(range.Contains("1.1.1"));
            Assert.IsFalse(range.Contains("1.2.2"));

        }

        [Test]
        public void TestTildaRangeContainRange()
        {
            var range = new Range("~1.2.3");
            var ContainRange = new Range(">=1.2.3 <1.3.0");
            var NotContainRange = new Range(">=0.0.0 <1.2.3");
            Assert.IsTrue(range.Contains(ContainRange));
            Assert.IsFalse(range.Contains(NotContainRange));
        }
    }
}
