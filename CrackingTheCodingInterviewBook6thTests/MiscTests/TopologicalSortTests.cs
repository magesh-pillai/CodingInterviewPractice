using NUnit.Framework;
using Misc;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace MiscTests
{
    [TestFixture]
    public class TopologicalSortTests
    {
        [Test]
        [TestCaseSource(nameof(DefaultTestCaseSource))]
        public void TopologicalSort_DefaultCases((int v, (int,int)[] edges, bool directed, bool expectedIsCycle, int[] expectedPath) data)
        {
            var g = new Graph(data.v, new List<(int,int)>(data.edges), data.directed);
            var subject = new TopologicalSort();

            subject.Sort(g);
            var results = subject.Results;

            Assert.AreEqual(data.expectedIsCycle, results.hasCycle);
            Assert.IsTrue(Enumerable.SequenceEqual(data.expectedPath, results.pathOrCycle));
        }

        private static IEnumerable<(int, (int,int)[], bool, bool, int[])> DefaultTestCaseSource()
        {
            var trivial = new [] 
            {
                (1,2)
            };
            yield return new (2, trivial, true, false, new [] {1,2});

            var trivialLoop = new []
            {
                (1,2), (2,1)
            };
            yield return new (2, trivialLoop, true, true, new [] {1,2});

            var degenerate = new []
            {
                (1,2), (2,3), (3,4), (4,5), (5,6), (6,7),
            };
            yield return new (7, degenerate, true, false, new [] {1,2,3,4,5,6,7});


            var g = new []
            {
                (1,2), (1,3),
                (2,3), (2,4),
                (3,5), (3,6),
                (5,4),
                (6,5),
                (7,1), (7,6),
            };

            yield return new (7, g, true, false, new [] {7,1,2,3,6,5,4});
        }
    }
}