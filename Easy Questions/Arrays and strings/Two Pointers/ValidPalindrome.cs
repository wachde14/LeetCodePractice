using NUnit.Framework;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    ///A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing
    ///all non-alphanumeric characters, it reads the same forward and backward.Alphanumeric characters 
    ///include letters and numbers.
    ///Given a string s, return true if it is a palindrome, or false otherwise.
    /// </summary>
    class ValidPalindrome
    {
        public bool IsPalindrome(string inputString)
        {
            inputString = inputString.ToLower();
            int left = 0;
            int right = inputString.Length - 1;

            while (left <= right)
            {
                if (!char.IsLetter(inputString[left]))
                {
                    left++;
                    continue;
                }

                if (!char.IsLetter(inputString[right]))
                {
                    right--;
                    continue;
                }

                if (char.IsLetter(inputString[left]) && char.IsLetter(inputString[right]) && inputString[left] != inputString[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }
    }

    [TestFixture]
    class ValidPalindromeTests
    {
        ValidPalindrome _practice = new ValidPalindrome();

        [TestCase("A man, a plan, a canal: Panama", true)]
        [TestCase("race a car", false)]
        [TestCase("racecar", true)]
        [TestCase(" ", true)]
        [TestCase("racgvhje a cahjr", false)]
        public void ValidPalindrome_WithVariousTestCases_ShouldReturnExpected(string input, bool expected)
        {
            bool result = _practice.IsPalindrome(input);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
