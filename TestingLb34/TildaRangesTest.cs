using NUnit.Framework;
using SemVer;
using System.Linq;

namespace TestingLb34
{
    class TildaRangesTest
    {
        [Test]
        public void EqualRanges()
        {
            var aRange = new Range("~1.2.3");
            var bRange = new Range(">=1.2.3 <1.3.0");
            Assert.IsTrue(aRange.Equals(bRange));
            Assert.IsTrue(aRange == bRange);
            Assert.IsFalse(aRange != bRange);
        }

        [Test]
        public void NotEqualRanges()
        {
            var aRange = new Range(">1.0.0 <2.0.0");
            var bRange = new Range(">1.0.0 <3.0.0");
            Assert.IsFalse(aRange.Equals(bRange));
            Assert.IsFalse(aRange == bRange);
            Assert.IsTrue(aRange != bRange);
        }

        [Test]
        public void EqualHashes()
        {
            var aRange = new Range("~1.2.3");
            var bRange = new Range(">=1.2.3 <1.3.0");
            Assert.IsTrue(aRange.GetHashCode().Equals(bRange.GetHashCode()));
        }
    }
}
