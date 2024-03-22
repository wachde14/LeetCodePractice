using DataStructures;
using NUnit.Framework;
namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// find the kth largest element in the array using a heap (priority queue) data structure.
    /// This problem can be solved using a MinHeap or MaxHeap depending on the approach taken.
    /// </summary>
    class KthLargestNumber
    {
        public int KthLargestNumberFromMinHeap(int[] nums, int k)
        {
            MinHeap minHeap = new MinHeap();
            foreach (int i in nums)
            {
                minHeap.Insert(i);
                if (minHeap.Count > k)
                {
                    minHeap.ExtractMin();
                }
            }

            return minHeap.ExtractMin();
        }
    }


    [TestFixture]
    class KthLargestNumberTests
    {
        KthLargestNumber _practice = new KthLargestNumber();

        [TestCase(new int[] { 3, 2, 1, 5, 6, 4 }, 2, 5)]
        [TestCase(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4)]
        [TestCase(new int[] { 5, 2, 7, 3, 6, 8, 1, 4 }, 3, 6)]
        [TestCase(new int[] { -1, 2, 0 }, 1, 2)]
        public void KthLargestNumber_WithInputArray_ShouldReturnExpected(int[] nums, int k, int expected)
        {
            int result = _practice.KthLargestNumberFromMinHeap(nums, k);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}

