using NUnit.Framework;

namespace Easy_Questions
{
    /// <summary>
    /// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// </summary>
    class TwoSum
    {
        public int[] TwoSumAnswerBruteForce(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target && i != j)
                        return new int[2] { i, j };
                }
            }
            return null;
        }
    }

    [TestFixture]
    class TwoSumTests
    {
        TwoSum twoSum = new TwoSum();

        [TestCase(new int[] { 1, 2, 3, 4 }, 7, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 8, 3, -5, 4 }, -1, new int[] { 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 36, null)]
        public void TwoSum_WithVariousTestCases_ShouldReturnExpected(int[] input, int target, int[] expected)
        {
            int[] result = twoSum.TwoSumAnswerBruteForce(input, target);

            Assert.AreEqual(expected, result);
        }
    }
}
