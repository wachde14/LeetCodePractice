using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medium_Questions
{
    /// <summary>
    /// Given a string, get all permutations of the string, but uppercase letters don't move 
    /// </summary>
    class StringPermutationsWithSpecialCharacters
    {
        public List<string> GetPermutationsWithSpecialCharacters(string input)
        {
            List<string> results = new List<string>();

            StringBuilder inputWithoutUppers = new StringBuilder(input);
            for (int i = inputWithoutUppers.Length - 1; i >= 0; i--)
            {
                if (char.IsUpper(inputWithoutUppers[i]))
                {
                    inputWithoutUppers.Remove(i, 1);
                }
            }
            string withoutUppers = inputWithoutUppers.ToString();

            Dictionary<char, int> charFreqDictionary = buildFreqTable(withoutUppers);

            GetPerms("", charFreqDictionary, withoutUppers.Length, results, input);

            return results;
        }

        void GetPerms(string prefix, Dictionary<char, int> map, int remaining, List<string> results, string originalInput)
        {
            if (remaining == 0)
            {
                StringBuilder prefixWithUppers = new StringBuilder(prefix);
                for (int i = 0; i < originalInput.Length; i++)
                {
                    if (char.IsUpper(originalInput[i]))
                    {
                        prefixWithUppers.Insert(i, originalInput[i].ToString(), 1);
                    }
                }
                string withUppers = prefixWithUppers.ToString();

                results.Add(withUppers);
                return;
            }
            else
            {
                foreach (char ch in map.Keys.ToList())
                {
                    int count = map[ch];
                    if (count > 0)
                    {
                        map[ch]--;
                        GetPerms(prefix + ch, map, remaining - 1, results, originalInput);
                        map[ch] = count;
                    }
                }
            }
        }

        Dictionary<char, int> buildFreqTable(string str)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char ch in str)
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
    class StringPermutationsWithSpecialCharactersTests
    {
        StringPermutationsWithSpecialCharacters _practice = new StringPermutationsWithSpecialCharacters();

        [TestCase("aab", 3)]
        [TestCase("aabb", 6)]
        [TestCase("aAbBCDSDFS", 2)]
        [TestCase("aAbBc", 6)]
        public void PhoneNumberGenerator_WithTestCases_ShouldReturnExpected(string input, int expected)
        {
            List<string> result = _practice.GetPermutationsWithSpecialCharacters(input);

            Assert.AreEqual(expected, result.Count);
        }
    }


}