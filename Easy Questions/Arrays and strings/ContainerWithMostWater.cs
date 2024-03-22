using System;
using NUnit.Framework;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// Given n non-negative integers a1, a2, ..., an , where each represents a point
    /// at coordinate (i, ai). n vertical lines are drawn such that the two endpoints
    /// of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis
    /// forms a container, such that the container contains the most water.
    /// Note: You may not slant the container and n is at least 2.
    /// </summary>
    class ContainerWithMostWater
    {
        public int MaxAreaBruteForce(int[] heights)
        {
            int maximumArea = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                for (int j = i + 1; j < heights.Length; j++)
                {
                    int currArea = Math.Min(heights[i], heights[j]) * (j - i);
                    if (currArea > maximumArea)
                        maximumArea = currArea;
                }
            }

            return maximumArea;
        }
    }

    [TestFixture]
    class ContainerWithMostWaterTests
    {
        readonly ContainerWithMostWater _practice = new ContainerWithMostWater();

        [TestCase(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        [TestCase(new int[] {1, 6, 49, 5, 42, 3, 2, 1, 27, 13}, 162)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 20)]
        [TestCase(new int[] { 3, 3, 3, 3 }, 9)]
        [TestCase(new int[] { 10, 5, 4, 9, 8, 13, 8, 12, 15, 8, 6, 3, 12, 6 }, 120)]
        public void GetJewelsCount_WithTestCases_ShouldReturnExpected(int[] inputHeights, int expected)
        {
            int result = _practice.MaxAreaBruteForce(inputHeights);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
