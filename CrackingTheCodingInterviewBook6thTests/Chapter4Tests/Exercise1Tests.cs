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
            var subject = new Graph(1, new List<(int, int)> { (0,0) }, true);

            Assert.IsTrue(RouteChecker.HasRoute(subject, 0, 0));
        }

        [Test]
        public void HasRoute_InvalidVertexIndex()
        {
            var subject = new Graph(2, new List<(int, int)> { (0,1), (1,0)  }, true);

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
                yield return new (2, new [] { (0,1), (1,0) }, 0, 1, true);
            }
        }
    }
}