using NUnit.Framework;
using System;

namespace Medium_Questions
{
    /// <summary>
    /// Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
    /// Example:
    /// Input: nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]
    /// Output: 6
    /// Explanation: [4, -1, 2, 1] has the largest sum = 6.
    /// </summary>
    public class MaximumSubarray
    {
        public int MaximumSubarraySolution(int[] input)
        {
            int largestTotal = input[0];
            for (int i = 0; i < input.Length; i++)
            {
                int runningTotal = input[i];
                largestTotal = Math.Max(largestTotal, runningTotal);

                for (int j = i + 1; j < input.Length; j++)
                {
                    runningTotal += input[j];
                    largestTotal = Math.Max(largestTotal, runningTotal);
                }
            }

            return largestTotal;
        }
    }

    [TestFixture]
    class MaximumSubarrayTests
    {
        MaximumSubarray _practice = new MaximumSubarray();

        [TestCase(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { -2, -3, -1, -5 }, -1)]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, -1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 15)]
        [TestCase(new int[] { 5, -8, 3, 2, 6, -7, 8 }, 12)]
        public void ColorfulNumbers_WithColorfulArray_ShouldReturnTrue(int[] input, int expected)
        {
            int result = _practice.MaximumSubarraySolution(input);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
