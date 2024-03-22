using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// Given an array A of strings made only from lowercase letters,
    /// return a list of all characters that show up in all strings within
    /// the list (including duplicates).  For example, if a character occurs 3
    /// times in all strings but not 4 times, you need to include that character
    /// three times in the final answer.
    /// </summary>
    class FindCommonCharacters
    {
        public List<char> GetCommonChars(List<string> strings)
        {
            if (!strings.Any())
                return new List<char>();

            List<Dictionary<char,int>> charFrequencyDictionaryList = new List<Dictionary<char, int>>();
            foreach (string currString in strings)
            {
                charFrequencyDictionaryList.Add(CreateFrequencyTable(currString));
            }

            return FindCommonLetters(charFrequencyDictionaryList);
        }

        private List<char> FindCommonLetters(List<Dictionary<char, int>> charFrequencyDictionaryList)
        {
            List<char> commonCharList = new List<char>();

            Dictionary<char, int> firstCharFrequencyDictioanry = charFrequencyDictionaryList.First();
            foreach (char currChar in firstCharFrequencyDictioanry.Keys)
            {
                int currentMin = firstCharFrequencyDictioanry[currChar];
                bool charFoundInAllWords = true;
                foreach (Dictionary<char, int> currCharFrequency in charFrequencyDictionaryList)
                {
                    if (!currCharFrequency.ContainsKey(currChar))
                    {
                        charFoundInAllWords = false;
                        break;
                    }

                    if (currCharFrequency[currChar] < currentMin)
                    {
                        currentMin = currCharFrequency[currChar];
                    }
                }

                if (charFoundInAllWords)
                {
                    for (int i = 0; i < currentMin; i++)
                    {
                        commonCharList.Add(currChar);
                    }
                }
            }

            return commonCharList;
        }

        private Dictionary<char, int> CreateFrequencyTable(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char ch in s)
            {
                if (!map.ContainsKey(ch))
                {
                    map.Add(ch, 0);
                }
                map[ch]++;
            }

            return map;
        }
    }

    [TestFixture]
    class FindCommonCharactersTests
    {
        readonly FindCommonCharacters _practice = new FindCommonCharacters();

        [TestCase(new string[] { "bella", "label", "roller" }, new char[] { 'e', 'l', 'l' })]
        [TestCase(new string[] { "cool", "lock", "cook" }, new char[] { 'c', 'o' })]
        [TestCase(new string[] { "abc", "cde", "efg" }, new char[] { })]
        [TestCase(new string[] { }, new char[] { })]
        [TestCase(new string[] { "aaabbb", "bbbccc", "bbbddd" }, new char[] { 'b', 'b', 'b' })]
        [TestCase(new string[] { "aaaaa", "aa", "aa" }, new char[] { 'a', 'a' })]
        [TestCase(new string[] { "aaaaaa", "aaaa", "a" }, new char[] { 'a' })]
        public void FindCommonCharacters_WithTestCases_ShouldReturnExpected(string[] inputStringList, char[] expectedStringList)
        {
            List<char> result = _practice.GetCommonChars(inputStringList.ToList());

            Assert.That(expectedStringList.ToList(), Is.EqualTo(result));
        }
    }
}
