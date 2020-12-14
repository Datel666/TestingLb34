using NUnit.Framework;
using SemVer;
using System.Linq;

namespace TestingLb34
{
    class TildaRangeContainsTest
    {
        [Test]
        public void TestTildaRanges1()
        {
            var comparatorA = new Comparator(">=1.2.3");
            var comparatorB = new Comparator("<1.3.0");
            var comparators = Interval.TildeRange("~1.2.3").Item2;
            Assert.AreEqual(comparators.Count(), 2);
            Assert.Contains(comparatorA, comparators);
            Assert.Contains(comparatorB, comparators);
        }

        [Test]
        public void TestTildaRanges2()
        {
            var comparatorA = new Comparator(">=1.2.0");
            var comparatorB = new Comparator("<1.3.0");
            var comparators = Interval.TildeRange("~1.2").Item2;
            Assert.AreEqual(comparators.Count(), 2);
            Assert.Contains(comparatorA, comparators);
            Assert.Contains(comparatorB, comparators);
        }

        [Test]
        public void TestTildaRanges3()
        {
            var comparatorA = new Comparator(">=1.0.0");
            var comparatorB = new Comparator("<2.0.0");
            var comparators = Interval.TildeRange("~1").Item2;
            Assert.AreEqual(comparators.Count(), 2);
            Assert.Contains(comparatorA, comparators);
            Assert.Contains(comparatorB, comparators);
        }

        [Test]
        public void TestTildaRanges4()
        {
            var comparatorA = new Comparator(">=0.2.3");
            var comparatorB = new Comparator("<0.3.0");
            var comparators = Interval.TildeRange("~0.2.3").Item2;
            Assert.AreEqual(comparators.Count(), 2);
            Assert.Contains(comparatorA, comparators);
            Assert.Contains(comparatorB, comparators);
        }

        [Test]
        public void TestTildaRanges5()
        {
            var comparatorA = new Comparator(">=0.2.0");
            var comparatorB = new Comparator("<0.3.0");
            var comparators = Interval.TildeRange("~0.2").Item2;
            Assert.AreEqual(comparators.Count(), 2);
            Assert.Contains(comparatorA, comparators);
            Assert.Contains(comparatorB, comparators);
        }

        [Test]
        public void TestTildaRanges6()
        {
            var comparatorA = new Comparator(">=0.0.0");
            var comparatorB = new Comparator("<1.0.0");
            var comparators = Interval.TildeRange("~0").Item2;
            Assert.AreEqual(comparators.Count(), 2);
            Assert.Contains(comparatorA, comparators);
            Assert.Contains(comparatorB, comparators);
        }
    }
}
