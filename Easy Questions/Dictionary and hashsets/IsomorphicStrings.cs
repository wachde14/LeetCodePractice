using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Easy_Questions
{
    /// <summary>
    /// Given two strings s and t, determine if they are isomorphic.
    /// Two strings are isomorphic if the characters in s can be replaced to get t.
    /// All occurrences of a character must be replaced with another character while preserving the order of characters.No two characters may map to the same character but a character may map to itself.
    /// </summary>
    class IsomorphicStrings
    {
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            return CreatePatternString(s) == CreatePatternString(t);
        }

        private string CreatePatternString(string s)
        {
            Dictionary<char, int> charToPatternIndexDictionary = new Dictionary<char, int>();
            StringBuilder patternRepresentation = new StringBuilder();

            int uniqueIndex = 0;
            foreach (char currChar in s)
            {
                if (!charToPatternIndexDictionary.ContainsKey(currChar))
                {
                    charToPatternIndexDictionary.Add(currChar, uniqueIndex);
                    patternRepresentation.Append(uniqueIndex);
                    uniqueIndex++;
                }
                else
                {
                    patternRepresentation.Append(charToPatternIndexDictionary[currChar]);
                }
            }

            return patternRepresentation.ToString();
        }
    }

    [TestFixture]
    class IsomorphicStringsTests
    {
        readonly IsomorphicStrings _practice = new IsomorphicStrings();

        [TestCase("", "", true)]
        [TestCase("ab", "cc", false)]
        [TestCase("bb", "cc", true)]
        [TestCase("bbsdfsdfsd", "cc", false)]
        [TestCase("aaabbb", "cccddd", true)]
        [TestCase("egg", "add", true)]
        [TestCase("foo", "bar", false)]
        [TestCase("paper", "title", true)]
        [TestCase("aaabbb", "cccddd", true)]
        public void IsomorphicStrings_WithTestCases_ShouldReturnExpected(string input1, string input2, bool expected)
        {
            bool result = _practice.IsIsomorphic(input1, input2);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
