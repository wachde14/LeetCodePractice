using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Hard_Questions
{
    /// <summary>
    /// Print all palindromes of size greater than or equal to 3 of a given string. (DP)
    /// </summary>
    class PrintAllPalindromes
    {
        public void PrintAllPalindromesRecursive(String str, double mid, int minSize, List<string> results)
        {
            if (mid < str.Length)
            {
                check(str, (int)Math.Floor(mid), (int)Math.Ceiling(mid), minSize, results);
                mid = mid + 0.5;
                PrintAllPalindromesRecursive(str, mid, minSize, results);
            }
        }

        public void check(String str, int start, int end, int minSize, List<string> results)
        {
            if (start >= 0 && end < str.Length && str[start] == str[end])
            {
                if (end - start + 1 >= minSize)
                {
                    results.Add(str.Substring(start, end - start + 1));
                }
                check(str, start - 1, end + 1, minSize, results);
            }
        }
    }


    [TestFixture]
    class ColorfulNumbersTests
    {
        PrintAllPalindromes _practice = new PrintAllPalindromes();

        [Test]
        public void ColorfulNumbers_WithColorfulArray_ShouldReturnTrue()
        {
            String str = "ababa";
            List<string> results = new List<string>();

            _practice.PrintAllPalindromesRecursive(str, 1, 3, results);
        }
    }
}
