using System.Linq;
using NUnit.Framework;

namespace Easy_Questions
{
    /// <summary>
    /// Count the number of prime numbers less than a non-negative number.
    /// </summary>
    class CountPrimes
    {
        public int GetPrimeCount(int upperLimit)
        {
            bool[] isPrime = new bool[upperLimit];
            for (int i = 2; i < upperLimit; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i * i < upperLimit; i++)
            {
                if (!isPrime[i])
                    continue;

                for (int j = i * i; j < upperLimit; j += i)
                {
                    isPrime[j] = false;
                }
            }

            return isPrime.Count(c => c);
        }
    }

    [TestFixture]
    class CountPrimesTests
    {
        readonly CountPrimes _countPrimes = new CountPrimes();

        [TestCase(1, 0)]
        [TestCase(3, 1)]
        [TestCase(7, 3)]
        [TestCase(10, 4)]
        [TestCase(100, 25)] 
        public void TwoSum_WithVariousTestCases_ShouldReturnExpected(int input, int expectedNumberPrimesLessThanInput)
        {
            int result = _countPrimes.GetPrimeCount(input);

            Assert.AreEqual(expectedNumberPrimesLessThanInput, result);
        }
    }
}
