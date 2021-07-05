using System;
using NUnit.Framework;

namespace Chapter1
{
    [TestFixture]
    public class Exercise1Tests
    {
        [Test]
        public void IsUnique_NullText_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => Exercise1.IsUnique(null));
        }
        
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