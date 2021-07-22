using NUnit.Framework;
using System.Collections.Generic;

namespace Chapter2
{
     [TestFixture]
    public class Exercise1Tests
    {
        [Test]
        public void RemoveDuplicates_Sanity_Test()
        {
            
        }


        public static T[] GetListData<T>(SinglyListNode<T> head)
        {
            var data = new List<T>(20);
            var current = head;
            while (current != null)
            {
                data.Add(current.Data);
                current = current.Next;
            }
            return data.ToArray(); 
        }

        private static SinglyListNode<T> BuildList<T>(T[] data)
        {
            if (data?.Length == 0)
            {
                return null;
            }

            var head = new SinglyListNode<T>(null, data[0]);
            var current = head;
            for(var i = 1; i < data.Length; i++)
            {
               current.Next = new SinglyListNode<T>(null, data[i]);
               current = current.Next;
            }

            return head;
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