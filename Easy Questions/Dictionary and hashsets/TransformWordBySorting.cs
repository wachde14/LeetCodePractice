using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// Write a function that when given two words, shows every step it takes to turn 
    /// the first word into the second word by only switching two letters that are touching. 
    /// For example MUG turning into GUM:
    ///   MUG
    ///   MGU
    ///   GMU
    ///   GUM
    /// </summary>
    class TransformWordBySorting
    {
        public List<string> GetTransformationList(char[] word1, char[] word2)
        {
            Dictionary<char, int> word1Map = buildFreqTable(new string(word1));
            Dictionary<char, int> word2Map = buildFreqTable(new string(word2));

            if (word1Map.Count != word2Map.Count || word1Map.Except(word2Map).Any())
                return null;


            List<string> results = new List<string>();
            results.Add(new string(word1));

            for (int i = 0; i < word2.Length; i++)
            {
                char currBaseChar = word2[i];
                for (int k = word1.Length - 1; k > 0; k--)
                {
                    if (word1[k] == currBaseChar)
                    {
                        while (k != i)
                        {
                            char previous = word1[k - 1];
                            word1[k - 1] = word1[k];
                            word1[k] = previous;
                            results.Add(new string(word1));
                            k--;
                        }
                        break;
                    }
                }
            }

            return results;
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
    class TransformWordBySortingTests
    {
        TransformWordBySorting _practice = new TransformWordBySorting();

        [TestCase(new char[] { 'M', 'U', 'G' }, new char[] { 'G', 'U', 'M' }, 4)]
        [TestCase(new char[] { 'M', 'U', 'G' }, new char[] { 'M', 'U', 'G' }, 1)]
        [TestCase(new char[] { 'A', 'B', 'C', 'D' }, new char[] { 'B', 'C', 'A', 'D' }, 3)]
        [TestCase(new char[] { 'A', 'B' }, new char[] { 'B', 'C', 'A', 'D' }, 0)]
        [TestCase(new char[] { 'A', 'B' }, new char[] { 'C', 'D' }, 0)]
        public void PasswordValidator_WithTestCases_ShouldReturnTrue(char[] word1, char[] word2, int expected)
        {
            List<string> results = _practice.GetTransformationList(word1, word2);

            int count = 0;
            if (results != null)
                count = results.Count;
                
            Assert.That(expected, Is.EqualTo(count));
        }
    }
}
