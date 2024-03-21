using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Easy_Questions
{
    /// <summary>
    /// Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.
    /// If the last word does not exist, return 0.
    /// Note: A word is defined as a character sequence consists of non-space characters only.
    /// </summary>
    class LengthOfLastWord
    {
        public int LengthOfLastWordReadable(string s)
        {
            List<string> wordList = s.Split(' ').ToList();

            return wordList.Last().Length;
        }

        public int LengthOfLastWordEfficient(string s)
        {
            int lastIndex = s.Length - 1;

            for (int i = lastIndex; i > 0; i--)
            {
                if (s[i] == ' ')
                {
                    return lastIndex - i;
                }
            }

            return s.Length;
        }
    }

    [TestFixture]
    class LengthOfLastWordReadableTests
    {
        readonly LengthOfLastWord _lengthOfLastWord = new LengthOfLastWord();

        [TestCase("", 0)]
        [TestCase("Hello World", 5)]
        [TestCase("The quick brown fox jumped over the lazy river.", 6)]
        [TestCase("abcdefghijklmnopqrstuvwxyz", 26)]
        public void LengthOfLastWordReadable_WithVariousTestCases_ShouldReturnExpected(string input, int expectedWordLength)
        {
            int result = _lengthOfLastWord.LengthOfLastWordReadable(input);

            Assert.That(expectedWordLength, Is.EqualTo(result));
        }

        [Test]
        public void LengthOfLastWordReadable_WithLongInput_ShouldReturnExpected()
        {
            string input = "Paragraphs are the building blocks of papers. Many students" +
                           " define paragraphs in terms of length: a paragraph is a group" +
                           " of at least five sentences, a paragraph is half a page long," +
                           " etc. In reality, though, the unity and coherence of ideas among" +
                           " sentences is what constitutes a paragraph. A paragraph is defined" +
                           " as “a group of sentences or a single sentence that forms a unit”" +
                           " (Lunsford and Connors 116). Length and appearance do not determine" +
                           " whether a section in a paper is a paragraph. For instance, in some" +
                           " styles of writing, particularly journalistic styles, a paragraph can" +
                           " be just one sentence long. Ultimately, a paragraph is a sentence or" +
                           " group of sentences that support one main idea. In this handout, we" +
                           " will refer to this as the “controlling idea,” because it controls" +
                           " what happens in the rest of the paragraph.";

            int result = _lengthOfLastWord.LengthOfLastWordReadable(input);

            Assert.That(10, Is.EqualTo(result));
        }
    }

    [TestFixture]
    class LengthOfLastWordEfficientTests
    {
        readonly LengthOfLastWord _lengthOfLastWord = new LengthOfLastWord();

        [TestCase("", 0)]
        [TestCase("Hello World", 5)]
        [TestCase("The quick brown fox jumped over the lazy river.", 6)]
        [TestCase("abcdefghijklmnopqrstuvwxyz", 26)]
        public void LengthOfLastWordEfficient_WithVariousTestCases_ShouldReturnExpected(string input, int expectedWordLength)
        {
            int result = _lengthOfLastWord.LengthOfLastWordEfficient(input);

            Assert.That(expectedWordLength, Is.EqualTo(result));
        }

        [Test]
        public void LengthOfLastWordEfficient_WithLongInput_ShouldReturnExpected()
        {
            string input = "Paragraphs are the building blocks of papers. Many students" +
                           " define paragraphs in terms of length: a paragraph is a group" +
                           " of at least five sentences, a paragraph is half a page long," +
                           " etc. In reality, though, the unity and coherence of ideas among" +
                           " sentences is what constitutes a paragraph. A paragraph is defined" +
                           " as “a group of sentences or a single sentence that forms a unit”" +
                           " (Lunsford and Connors 116). Length and appearance do not determine" +
                           " whether a section in a paper is a paragraph. For instance, in some" +
                           " styles of writing, particularly journalistic styles, a paragraph can" +
                           " be just one sentence long. Ultimately, a paragraph is a sentence or" +
                           " group of sentences that support one main idea. In this handout, we" +
                           " will refer to this as the “controlling idea,” because it controls" +
                           " what happens in the rest of the paragraph.";

            int result = _lengthOfLastWord.LengthOfLastWordEfficient(input);

            Assert.That(10, Is.EqualTo(result));
        }
    }
}