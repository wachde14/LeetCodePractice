using NUnit.Framework;
using System;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
    /// Example:
    /// Input: nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]
    /// Output: 6
    /// Explanation: [4, -1, 2, 1] has the largest sum = 6.
    /// </summary>
    public class MaximumSubarrayTimeOptimized
    {
        public int MaximumSubarrayTimeOptimizedSolution(int[] input)
        {
            int maxEndingHere = input[0];
            int maxSoFar = input[0];

            for (int i = 1; i < input.Length; i++)
            {
                maxEndingHere = Math.Max(input[i], maxEndingHere + input[i]);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
        }
    }

    [TestFixture]
    class MaximumSubarrayTimeOptimizedTests
    {
        MaximumSubarrayTimeOptimized _practice = new MaximumSubarrayTimeOptimized();

        [TestCase(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { -2, -3, -1, -5 }, -1)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, -1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 15)]
        [TestCase(new int[] { 5, -8, 3, 2, 6, -7, 8 }, 12)]
        public void ColorfulNumbers_WithColorfulArray_ShouldReturnTrue(int[] input, int expected)
        {
            int result = _practice.MaximumSubarrayTimeOptimizedSolution(input);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
