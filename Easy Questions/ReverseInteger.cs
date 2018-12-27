using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Easy_Questions
{
    /// <summary>
    /// Given a 32-bit signed integer, reverse digits of an integer wihtout casting to a string.
    /// </summary>
    class ReverseInteger
    {
        public int ReverseInt(int input)
        {
            if (input == 0)
                return 0;

            int positiveInput = Math.Abs(input);

            Queue<int> queue = new Queue<int>();
            while (positiveInput != 0)
            {
                int rightMostDigit = positiveInput % 10;
                queue.Enqueue(rightMostDigit);
                positiveInput /= 10;
            }

            int result = 0;
            while (queue.Count > 0)
            {
                result = (result * 10) + queue.Dequeue();
            }

            if (input < 0)
                return result * -1;

            return result;
        }
    }

    [TestFixture]
    class ReverseIntegerTests
    {
        ReverseInteger _practice = new ReverseInteger();

        [TestCase(123, 321)]
        [TestCase(-123, -321)]
        [TestCase(120, 21)]
        [TestCase(0, 0)]
        [TestCase(1234566, 6654321)]
        public void ReverseInteger_WithTestCases_ShouldReturnExpected(int input, int expected)
        {
            int result = _practice.ReverseInt(input);

            Assert.AreEqual(expected, result);
        }
    }
}
