using NUnit.Framework;

namespace Easy_Questions
{
    /// <summary>
    /// Given two sorted integer arrays, merge them into one sorted array.
    /// </summary>
    class MergeSortedArrays
    {
        public int[] MergeArrays(int[] array1, int[] array2)
        {
            int newArraySize = array1.Length + array2.Length;
            int[] mergedArray = new int[newArraySize];

            int firstArrayIncrementor = 0;
            int secondArrayIncrementor = 0;
            for (int i = 0; i < newArraySize; i++)
            {
                if (firstArrayIncrementor >= array1.Length)
                {
                    mergedArray[i] = array2[secondArrayIncrementor];
                    secondArrayIncrementor++;
                    continue;
                }

                if (secondArrayIncrementor >= array2.Length)
                {
                    mergedArray[i] = array1[firstArrayIncrementor];
                    firstArrayIncrementor++;
                    continue;
                }

                if (array1[firstArrayIncrementor] < array2[secondArrayIncrementor])
                {
                    mergedArray[i] = array1[firstArrayIncrementor];
                    firstArrayIncrementor++;
                }
                else
                {
                    mergedArray[i] = array2[secondArrayIncrementor];
                    secondArrayIncrementor++;
                }
            }

            return mergedArray;
        }
    }

    [TestFixture]
    class MergeSortedArraysTests
    {
        readonly MergeSortedArrays _mergeSortedArrays = new MergeSortedArrays();

        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3,}, new int[] { 2 }, new int[] { 1, 2, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 3 }, new int[] { 1, 2, 3, 3, 4 })]
        [TestCase(new int[] { }, new int[] { 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3 }, new int[] { 1, 2, 2, 3, 3, 4 })]
        public void TwoSum_WithVariousTestCases_ShouldReturnExpected(int[] inputArray1, int[] inputArray2, int[] expected)
        {
            int[] result = _mergeSortedArrays.MergeArrays(inputArray1, inputArray2);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
