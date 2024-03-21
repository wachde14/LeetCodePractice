using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Medium_Questions
{
    /// <summary>
    /// Find all the possible passwords, given the length of the password and 
    /// that it is a well ordered number (159 is well-ordered as 1<5<9)
    /// </summary>
    class FindAllPossiblePasswords
    {
        public List<string> FindAllPasswords(int lengthOfPassword)
        {
            List<string> results = new List<string>();
            GetPerms(results, "", lengthOfPassword);

            return results;
        }

        void GetPerms(List<string> results, string prefix, int remaining)
        {
            if (remaining == 0)
            {
                results.Add(prefix);
                return;
            }

            int previous = 0;
            if (prefix.Length > 0)
            {
                string previousString = prefix[prefix.Length - 1].ToString();
                previous = Convert.ToInt32(previousString);
            }

            for (int i = 0; i <= 9; i++)
            {
                if (prefix.Length == 0 || (prefix.Length > 0 && i > previous))
                {
                    string newPrefix = prefix + i;
                    GetPerms(results, newPrefix, remaining - 1);
                }
            }
        }
    }

    [TestFixture]
    class FindAllPasswordsTests
    {
        FindAllPossiblePasswords _practice = new FindAllPossiblePasswords();

        [TestCase(2, 45)]
        [TestCase(3, 120)]
        [TestCase(4, 210)]
        [TestCase(5, 252)]
        [TestCase(6, 210)]
        public void FindAllPasswords_WithTestCases_ShouldReturnExpected(int input, int expected)
        {
            List<string> result = _practice.FindAllPasswords(input);

            Assert.That(expected, Is.EqualTo(result.Count));
        }
    }
}
