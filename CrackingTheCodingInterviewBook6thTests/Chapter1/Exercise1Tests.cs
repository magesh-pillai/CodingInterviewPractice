using System;
using NUnit.Framework;

namespace Chapter1
{
    [TestFixture]
    public class Chapter1Tests
    {
        [TestCase("", true)]
        [TestCase("a", true)]
        [TestCase("abc", true)]
        [TestCase("aa", false)]
        [TestCase("abcdefghijklmno123456789a", false)]
        public void IsUniqueTests(string text, bool result)
        {
            Assert.AreEqual(result, Exercise1.IsUnique(text));
        }
    }
}