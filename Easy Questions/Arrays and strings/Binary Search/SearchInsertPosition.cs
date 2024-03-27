using NUnit.Framework;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// Given a sorted array of distinct integers and a target value, return the index if the target is found. 
    /// If not, return the index where it would be if it were inserted in order.
    /// You must write an algorithm with O(log n) runtime complexity.
    /// </summary>
    class SearchInsertPosition
    {
        public int GetSearchInsertPosition(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }
    }

    [TestFixture]
    class SearchInsertPositionTests
    {
        readonly SearchInsertPosition _searchInsertPosition = new SearchInsertPosition();

        [TestCase(new int[] { 1, 3, 5, 6 }, 5, 2)]
        [TestCase(new int[] { 1, 3, 5, 6 }, 2, 1)]
        [TestCase(new int[] { 1, 3, 5, 6 }, 7, 4)]
        public void TwoSum_WithVariousTestCases_ShouldReturnExpected(int[] inputArray, int target, int expected)
        {
            int result = _searchInsertPosition.GetSearchInsertPosition(inputArray, target);

            Assert.That(expected == result);
        }
    }
}
