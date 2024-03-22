using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// Given a string, find the length of the longest substring without repeating characters.
    /// </summary>
    public class LongestSubstringWithoutRepeatingCharacters
    {
        public int SlidingWindowSolution(string str)
        {
            HashSet<char> charSet = new HashSet<char>();
            int stringLength = str.Length;

            int result = 0, i = 0, j = 0;
            while (i < stringLength && j < stringLength)
            {
                // try to extend the range [i, j]
                if (!charSet.Contains(str[j]))
                {
                    charSet.Add(str[j]);
                    j++;

                    result = Math.Max(result, j - i);
                }
                else
                {
                    charSet.Remove(str[i]);
                    i++;
                }
            }

            return result;
        }
    }

    [TestFixture]
    class LongestSubstringWithoutRepeatingCharactersTests
    {
        LongestSubstringWithoutRepeatingCharacters _practice = new LongestSubstringWithoutRepeatingCharacters();

        [TestCase("abcabcbb", 3)]
        [TestCase("abcdefghijklmopqrstuvwxyz", 25)]
        [TestCase("aaaaaaaaaaaaaaa", 1)]
        public void LongestSubstring_WithVariousTestCases_ShouldReturnExpected(string inputString, int expected)
        {
            int result = _practice.SlidingWindowSolution(inputString);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
