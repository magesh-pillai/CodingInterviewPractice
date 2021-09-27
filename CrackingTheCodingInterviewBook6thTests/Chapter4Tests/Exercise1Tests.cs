using NUnit.Framework;
using Chapter4;
using Common;
using System;
using System.Collections.Generic;

namespace Chapter4Tests
{
    [TestFixture]
    public class Exercise1Tests
    {
        [Test]
        public void HasRoute_SingleNodeWithSelfLoopGraph()
        {
            var subject = new Graph(1, new List<(int, int)> { (1,1) }, true);

            Assert.IsTrue(RouteChecker.HasRoute(subject, 1, 1));
        }

        [Test]
        public void HasRoute_InvalidVertexIndex()
        {
            var subject = new Graph(2, new List<(int, int)> { (1,2), (2,1)  }, true);

             Assert.Throws(typeof(ArgumentOutOfRangeException), () => RouteChecker.HasRoute(subject, 5, 1));
        }

        [Test]
        [TestCaseSource(nameof(DefaultTestCaseSource))]
        public void HasRoute_ValidTargets((int v, (int, int)[] edges, int s, int t, bool expected) data)
        {
            var subject = new Graph(data.v, new List<(int, int)>(data.edges), true);

            Assert.AreEqual(data.expected, RouteChecker.HasRoute(subject, data.s, data.t));
        }

        private static IEnumerable<(int, (int, int)[], int, int, bool)> DefaultTestCaseSource
        {
            get
            {
                yield return new (2, new [] { (1,2), (2,1) }, 1, 2, true);

                var g1 = new [] { (1,2), (4,1), (4,3), (5,1) };
                yield return new (5, g1, 4, 5, false);
                yield return new (5, g1, 4, 3, true);
                yield return new (5, g1, 4, 2, true);
                yield return new (5, g1, 5, 2, true);
                yield return new (5, g1, 5, 3, false);
            }
        }
    }
}