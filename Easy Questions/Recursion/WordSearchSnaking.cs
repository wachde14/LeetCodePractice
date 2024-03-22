using NUnit.Framework;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// Create a method that can determine whether a word can be found
    /// in a word search. Words can be connected up, down, left, or right
    /// in a snaking fashion. i.e. the letters of the words need to be touching
    /// and are not required to be all going the same direction.
    /// </summary>
    class WordSearchSnaking
    {
        public bool IsWordInMatrix(char[,] matrix, string targetWord)
        {
            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                for (int l = 0; l < matrix.GetLength(1); l++)
                {
                    char currChar = matrix[k, l];
                    if (currChar == targetWord[0])
                    {
                        if (DoesMatrixContainWord(k, l, 0, matrix, targetWord))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool DoesMatrixContainWord(int row, int column, int index, char[,] matrix, string targetWord)
        {

            if (index >= targetWord.Length)
            {
                return true;
            }

            if (row < 0 || row >= matrix.GetLength(0) || column < 0 || column >= matrix.GetLength(1) || targetWord[index] != matrix[row, column])
            {
                return false;
            }

            if (DoesMatrixContainWord(row + 1, column, index + 1, matrix, targetWord) ||
            DoesMatrixContainWord(row, column + 1, index + 1, matrix, targetWord) ||
            DoesMatrixContainWord(row - 1, column, index + 1, matrix, targetWord) ||
            DoesMatrixContainWord(row, column - 1, index + 1, matrix, targetWord))
            {
                return true;
            }

            return false;
        }
    }


    [TestFixture]
    class WordSearchSnakingTests
    {
        WordSearchSnaking _practice = new WordSearchSnaking();

        [TestCase("azbmlrxmd", true)]
        [TestCase("remxmdbpkjx", true)]
        [TestCase("abcrem", true)]
        [TestCase("pbd", true)]
        [TestCase("b", true)]
        [TestCase("abcddd", false)]
        [TestCase("zzzz", false)]
        [TestCase("iyuyuy", false)]
        [TestCase("mee", false)]
        [TestCase("aaaa", false)]
        public void WordSearch_WithTestCases_ShouldReturnTrue(string targetWord, bool expected)
        {
            char[,] matrix = new char[,]
            {
                {'a',  'b',  'c',  'r',  'e'},
                {'z',  'b',  'h',  'e',  'm'},
                {'t',  'm',  'l',  'r',  'x'},
                {'x',  'f',  'c',  'e',  'm'},
                {'j',  'k',  'p',  'b',  'd'}
            };

            bool result = _practice.IsWordInMatrix(matrix, targetWord);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}

