using NUnit.Framework;
using System.Collections.Generic;

namespace Easy_Questions
{
    // Given an array of integers arr, a lucky integer is an integer which has a frequency in the array equal to its value.
    // Return a lucky integer in the array. If there are multiple lucky integers return the largest of them. If there is no lucky integer return -1.
    public class LuckyInteger
    {
        public int FindLucky(int[] arr)
        {
            Dictionary<int, int> numberFrequencyDictionary = new Dictionary<int, int>();
            foreach (int currInt in arr)
            {
                if (!numberFrequencyDictionary.ContainsKey(currInt))
                {
                    numberFrequencyDictionary.Add(currInt, 1);
                }
                else
                {
                    numberFrequencyDictionary[currInt]++;
                }
            }

            int maxLuckyNumberFound = -1;
            foreach (int currInt in arr)
            {
                if (numberFrequencyDictionary[currInt] == currInt && currInt > maxLuckyNumberFound)
                {
                    maxLuckyNumberFound = numberFrequencyDictionary[currInt];
                }
            }

            return maxLuckyNumberFound;
        }

        [TestFixture]
        class LuckyIntegerTests
        {
            [Test]
            [TestCase(new int[] { 2, 2, 3, 4 }, 2)]
            [TestCase(new int[] { 1, 5, 5, 4, 5, 5, 5, 3, 9, 8 }, 5)]
            [TestCase(new int[] { -1, -6, -5, 5, 39, 45, 3 }, -1)]
            [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
            public void FindLucky_WithTestCases_ShouldReturnExpected(int[] input, int expected)
            {
                LuckyInteger luckyInt = new LuckyInteger();
                int result = luckyInt.FindLucky(input);

                Assert.AreEqual(expected, result);
            }
        }
    }
}
