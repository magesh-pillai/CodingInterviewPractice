using NUnit.Framework;

namespace Chapter1
{
    [TestFixture]
    public class Exercise2Tests
    {
       
        [TestCase(null, null, true)]
        [TestCase(null, "", false)]
        [TestCase("", null, false)]
        [TestCase("1", "11", false)]
        [TestCase("1", "1", true)]
        [TestCase("aba", "aba", true)]
        [TestCase("abcabc", "acbaac", false)]
        public void CheckPermutationTests(string input1, string input2, bool result)
        {
            Assert.AreEqual(result, Exercise2.CheckPermutation(input1, input2));
        }
    }
}