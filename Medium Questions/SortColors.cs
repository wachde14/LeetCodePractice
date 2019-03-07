using System.Linq;
using NUnit.Framework;

namespace Medium_Questions
{
    /// <summary>
    /// Given an array with n objects colored red, white or blue, sort them in-place
    /// so that objects of the same color are adjacent, with the colors in the order red, white and blue.
    /// Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
    /// Come up with a one-pass algorithm using only constant space
    /// </summary>
    class SortColors
    {
        /// <summary>
        /// The one pass solution is much less readable than the 2-pass solution.
        /// I believe we are trading effeciency for readability and maintainability in this case.
        /// </summary>
        /// <param name="nums"></param>
        public void SortColorsOnePass(int[] nums)
        {
            int leftIndex = 0;
            int rightIndex = nums.Length - 1;

            for (int i = 0; i <= rightIndex; i++)
            {
                if (nums[i] == 0 && i != leftIndex)     //if it's 0, swap to the left
                {
                    nums[i--] = nums[leftIndex];        //stay at the same index for next round
                    nums[leftIndex++] = 0;
                }
                else if (nums[i] == 2)                  //if it's 2, swap to the right
                {
                    nums[i--] = nums[rightIndex];
                    nums[rightIndex--] = 2;
                }
            }
        }
    }

    [TestFixture]
    class SortColorsTests
    {
        readonly SortColors _practice = new SortColors();

        [TestCase(new int[] { 2, 0, 2, 1, 1, 0 })]
        [TestCase(new int[] { 2, 0, 1, 0, 2, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1})]
        [TestCase(new int[] { 2, 2, 2, 2, 2, 2, 2, 2 })]
        [TestCase(new int[] { 2, 2, 2, 2, 2, 2, 0, 2 })]
        [TestCase(new int[] { 2, 2, 2, 2, 2, 1, 2, 2 })]
        public void SortColors_WithTestCases_ShouldReturnExpected(int[] inputNums)
        {
            _practice.SortColorsOnePass(inputNums);

            Assert.AreEqual(inputNums.OrderBy(x => x), inputNums);
        }
    }
}
