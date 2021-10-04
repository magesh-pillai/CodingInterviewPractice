using NUnit.Framework;
using Misc;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiscTests
{
    [TestFixture]
    public class BreadthFirstSearchTests
    {
        [Test]
        [TestCaseSource(nameof(DefaultTestCaseSource))]
        public void BreadthFirstSearch_DefaultCases((int v, (int, int)[] edges, int s, int t, bool directed, int[] expectedPath) data)
        {
            var g = new Graph(data.v, new List<(int, int)>(data.edges), data.directed);
            var subject = new BreadthFirstSearch();

            subject.Search(g, data.s);
            var path = subject.FindPath(data.s, data.t);

            Assert.IsTrue(Enumerable.SequenceEqual(data.expectedPath, path));
        }

        private static IEnumerable<(int, (int, int)[], int, int, bool, int[])> DefaultTestCaseSource
        {
            get
            {
                var g = new []
                {
                    (1,2), (1,5), (1,6),
                    (2,3), (2,5),
                    (3,4),
                    (4,5)
                };

                yield return new(6, g, 1, 4, false, new [] {1,5,4});
                yield return new(6, g, 1, 3, false, new [] {1,2,3});
                yield return new(6, g, 1, 1, false, new [] {1});

                var degenerate = new []
                {
                    (1,2), (2,3), (3,4), (4,5), (5,6), (6,7)
                };
                yield return new(7, degenerate, 1, 7, false, new [] {1,2,3,4,5,6,7});
                yield return new(7, degenerate, 1, 7, true, new [] {1,2,3,4,5,6,7});

                var trivialLoop = new []
                {
                    (1,2)
                };
                yield return new(2, trivialLoop, 1, 2, false, new [] {1,2});
                yield return new(2, trivialLoop, 1, 2, true, new [] {1,2});
            }
        }
    }
}