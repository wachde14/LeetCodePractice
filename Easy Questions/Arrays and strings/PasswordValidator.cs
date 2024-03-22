using NUnit.Framework;
using System.Collections.Generic;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// <p>Verify if the given password is valid/invalid:
    /// 1. must be 5-12 characters long
    /// 2. must contain atleast one number and one lowercase character
    /// 3. sequence must not be followed by the same sequence(like 123123qs is invalid, 123qs123 is valid)
    /// </summary>
    class PasswordValidator
    {
        public bool IsValidPassword(string password)
        {
            return HasValidLength(password) && HasOneLowercaseLetter(password) 
                && HasOneNumber(password) && !HasRepeatingSequence(password);
        }

        bool HasOneNumber(string password)
        {
            foreach (char ch in password)
            {
                if (char.IsDigit(ch))
                {
                    return true;
                }
            }

            return false;
        }

        bool HasOneLowercaseLetter(string password)
        {
            foreach (char ch in password)
            {
                if (char.IsLower(ch))
                {
                    return true;
                }
            }

            return false;
        }

        bool HasValidLength(string password)
        {
            if (password.Length < 5 || password.Length > 12)
            {
                return false;
            }

            return true;
        }

        bool HasRepeatingSequence(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char currChar = password[i];
                Queue<char> possibleSequenceQueue = new Queue<char>();
                for (int k = i + 1; k < password.Length - 1; k++)
                {
                    if (password[k] == currChar)
                    {
                        if (DoesMatchStoredSequence(possibleSequenceQueue, password, k + 1))
                        {
                            return true;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        possibleSequenceQueue.Enqueue(password[k]);
                    }
                }
            }

            return false;
        }

        bool DoesMatchStoredSequence(Queue<char> possibleSequenceQueue, string password, int startingIndex)
        {
            if (possibleSequenceQueue.Count == 0)
            {
                return true;
            }

            int currIndex = startingIndex;
            while (currIndex < password.Length && possibleSequenceQueue.Count != 0)
            {
                if (possibleSequenceQueue.Dequeue() != password[currIndex])
                {
                    return false;
                }

                currIndex++;
            }

            if (possibleSequenceQueue.Count > 0)
                return false;

            return true;
        }
    }

    [TestFixture]
    class PasswordValidatorTests
    {
        PasswordValidator _practice = new PasswordValidator();

        [TestCase("123123qs", false)]
        [TestCase("123qs123", true)]
        [TestCase("abcd", false)]
        [TestCase("ABCDEFHSD", false)]
        [TestCase("aBc1212ab", false)]
        [TestCase("123s123", true)]
        [TestCase("AbkE7434", true)]
        public void PasswordValidator_WithTestCases_ShouldReturnTrue(string password, bool expected)
        {
            bool result = _practice.IsValidPassword(password);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
