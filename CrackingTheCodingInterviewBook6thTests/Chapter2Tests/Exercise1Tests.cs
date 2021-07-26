using NUnit.Framework;
using System.Collections.Generic;
using Chapter2;

namespace Chapter2Tests
{
     [TestFixture]
    public class Exercise1Tests
    {
        [Test]
        public void RemoveDuplicates_NullCheck()
        {
            var subject = Exercise1.RemoveDuplicates(null, Comparer<string>.Default);    
            Assert.IsNull(subject);
        }

        [TestCase(new [] {"a"}, new [] {"a"})]
        [TestCase(new [] {"a", "a", "a"}, new [] {"a"})]
        [TestCase(new [] {"a", "b", "a"}, new [] {"a", "b"})]
        [TestCase(new [] {"b", "b", "b", "a"}, new [] {"b", "a"})]
        [TestCase(new string[0], new string[0])]
        public void RemoveDuplicates_Sanity_Test(string[] input, string[] expected)
        {
            var subject = SinglyListNode<string>.BuildList(input);
            subject = Exercise1.RemoveDuplicates(subject, Comparer<string>.Default);           
            var actual = SinglyListNode<string>.GetListData(subject);

            AssertAreEqual<string>(expected, actual, Comparer<string>.Default);
        }
        
        private static void AssertAreEqual<T>(T[] expected, T[] actual, IComparer<T> comparer)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for(var i = 0; i < expected.Length; i++)
            {
                Assert.IsTrue(comparer.Compare(expected[i], actual[i]) == 0);
            }
        }
    } 
}