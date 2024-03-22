using NUnit.Framework;
using System.Collections.Generic;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    /// An input string is valid if:
    ///  Open brackets must be closed by the same type of brackets.
    ///  Open brackets must be closed in the correct order.
    ///  Note that an empty string is also considered valid.
    /// </summary>
    class ValidParentheses
    {
        public bool IsValidParens(string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> parenDict = new Dictionary<char, char>()
            {
                { ')', '('},
                { ']', '['},
                { '}', '{'}
            };
            
            foreach (char ch in input)
            {
                if (parenDict.ContainsValue(ch))
                {
                    stack.Push(ch);
                    continue;
                }

                if (parenDict.ContainsKey(ch))
                {
                    if (stack.Count == 0 || stack.Pop() != parenDict[ch])
                        return false;
                }
            }

            if (stack.Count > 0)
                return false;

            return true;
        }
    }

    [TestFixture]
    class ValidParenthesesTests
    {
        ValidParentheses _practice = new ValidParentheses();

        [TestCase("]", false)]
        [TestCase("()", true)]
        [TestCase("()[]()", true)]
        [TestCase("(]", false)]
        [TestCase("([)]", false)]
        [TestCase("{[]}", true)]
        [TestCase("", true)]
        [TestCase("(sdfg[sdfg)gd]", false)]
        [TestCase("sdg{dsfg[sdfg]sdfg}", true)]
        public void TwoSum_WithVariousTestCases_ShouldReturnExpected(string input, bool expected)
        {
            bool result = _practice.IsValidParens(input);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
