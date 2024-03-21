using NUnit.Framework;

namespace Easy_Questions
{
    /// <summary>
    /// Implement strStr().
    //    Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
    //    Clarification:
    //What should we return when needle is an empty string? This is a great question to ask during an interview.
    //    For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().
    //    Example 1:
    //    Input: haystack = "hello", needle = "ll"
    //    Output: 2
    //Example 2:
    //    Input: haystack = "aaaaa", needle = "bba"
    //    Output: -1
    //Example 3:
    //    Input: haystack = "", needle = ""
    //    Output: 0
    /// </summary>
    class NeedleInHaystack
    {
        public int strStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            int currIndex = 0;
            foreach (char currChar in haystack)
            {
                if (currChar == needle[0])
                {
                    if (isContained(haystack.Substring(currIndex), needle))
                    {
                        return currIndex;
                    }
                }
                currIndex++;
            }

            return -1;
        }

        public bool isContained(string containerSubset, string target)
        {
            for (int i = 0; i <= target.Length - 1; i++)
            {
                if (containerSubset[i] != target[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

    [TestFixture]
    class NeedleInHaystackTests
    {
        readonly NeedleInHaystack _needleInHaystack = new NeedleInHaystack();

        [TestCase("hello", "ll", 2)]
        [TestCase("aaaaa", "bba", -1)]
        [TestCase("", "", 0)]
        [TestCase("hello", "o", 4)]
        [TestCase("123456789bba", "bba", 9)]
        [TestCase("123456789", "9", 8)]
        public void strStr_WithVariousTestCases_ShouldReturnExpected(string haystack, string needle, int expected)
        {
            int result = _needleInHaystack.strStr(haystack, needle);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
