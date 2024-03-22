using NUnit.Framework;
using System.Collections.Generic;

namespace Easy_and_Medium_Questions
{
    class PhoneNumberGenerator
    {
        public List<string> GeneratePhoneNumbers(int numOfDigits)
        {
            List<string> results = new List<string>();

            GenPhoneNumbers(0, "", numOfDigits, results);

            return results;
        }

        private void GenPhoneNumbers(int index, string prefix, int numOfDigits, List<string> results)
        {
            if (index == numOfDigits)
            {
                results.Add(prefix);
                return;
            }

            for (int i = 0; i <= 9; i++)
            {
                string newPrefix = prefix + i;
                GenPhoneNumbers(index + 1, newPrefix, numOfDigits, results);
            }
        }
    }


    [TestFixture]
    class PhoneNumberGeneratorTests
    {
        PhoneNumberGenerator _practice = new PhoneNumberGenerator();

        [TestCase(2, 100)]
        [TestCase(3, 1000)]
        [TestCase(4, 10000)]
        public void PhoneNumberGenerator_WithTestCases_ShouldReturnExpected(int input, int expected)
        {
            List<string> result = _practice.GeneratePhoneNumbers(input);

            Assert.That(expected, Is.EqualTo(result.Count));
        }
    }
}