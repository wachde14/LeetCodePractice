using System.Collections.Generic;
using NUnit.Framework;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// You're given strings J representing the types of stones that are jewels, and S representing
    /// the stones you have.  Each character in S is a type of stone you have.
    /// You want to know how many of the stones you have are also jewels.
    /// The letters in J are guaranteed distinct, and all characters in J and S are letters.
    /// Letters are case sensitive, so "a" is considered a different type of stone from "A".
    /// </summary>
    class JewelsAndStones
    {
        public int GetJewelsCount(string jewels, string stones)
        {
            HashSet<char> uniqueJewels = new HashSet<char>();
            foreach (char currChar in jewels)
            {
                if (!uniqueJewels.Contains(currChar))
                {
                    uniqueJewels.Add(currChar);
                }
            }

            int jewelCount = 0;
            foreach (char currChar in stones)
            {
                if (uniqueJewels.Contains(currChar))
                {
                    jewelCount++;
                }
            }

            return jewelCount;
        }
    }

    [TestFixture]
    class JewelsAndStonesTests
    {
        readonly JewelsAndStones _practice = new JewelsAndStones();

        [TestCase("aA", "aAAbbbb", 3)]
        [TestCase("z", "ZZ", 0)]
        [TestCase("", "", 0)]
        [TestCase("abc", "detereabererweqc", 3)]
        [TestCase("", "aAAbbbb", 0)]
        [TestCase("asdfsd", "", 0)]
        [TestCase("abc", "abcabcabcabcabc", 15)]
        [TestCase("a", "ZaaaaaaaaaaZ", 10)]
        public void GetJewelsCount_WithTestCases_ShouldReturnExpected(string inputJewels, string inputStones, int expected)
        {
            int result = _practice.GetJewelsCount(inputJewels, inputStones);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
