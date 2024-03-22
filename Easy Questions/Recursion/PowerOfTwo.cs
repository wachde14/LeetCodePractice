using NUnit.Framework;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// Given an integer, write a function to determine if it is a power of two.
    /// </summary>
    class PowerOfTwo
    {
        public bool IsPowerOfTwo(int n)
        {
            for (int i = 1; i <= n; i *= 2)
            {
                if (i == n)
                    return true;
            }

            return false;
        }
    }

    [TestFixture]
    class PowerOfTwoTests
    {
        readonly PowerOfTwo _powerOfTwo = new PowerOfTwo();

        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, false)]
        [TestCase(4, true)]
        [TestCase(5, false)]
        [TestCase(6, false)]
        [TestCase(262143, false)]
        [TestCase(262144, true)]
        [TestCase(16777215, false)]
        [TestCase(16777216, true)]
        public void TwoSum_WithVariousTestCases_ShouldReturnExpected(int input, bool expected)
        {
            bool result = _powerOfTwo.IsPowerOfTwo(input);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
