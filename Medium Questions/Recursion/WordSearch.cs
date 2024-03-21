using NUnit.Framework;

namespace Medium_Questions
{
    /// <summary>
    /// Create a method that can determine whether a word can be found
    /// in a word search. Words can be found up, down, left, or right. 
    /// Diagonal words are not valid.
    /// </summary>
    class WordSearch
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
                        if (DoesMatrixContainWord(k, l, 0, matrix, targetWord, Direction.Down) ||
                            DoesMatrixContainWord(k, l, 0, matrix, targetWord, Direction.Up) ||
                            DoesMatrixContainWord(k, l, 0, matrix, targetWord, Direction.Left) ||
                            DoesMatrixContainWord(k, l, 0, matrix, targetWord, Direction.Right) )
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool DoesMatrixContainWord(int row, int column, int index, char[,] matrix, string targetWord, Direction dir)
        {

            if (index >= targetWord.Length)
            {
                return true;
            }

            if (row < 0 || row >= matrix.GetLength(0) || column < 0 || column >= matrix.GetLength(1) || targetWord[index] != matrix[row, column])
            {
                return false;
            }

            bool foundMatch = false;
            switch (dir)
            {
                case Direction.Up:
                     foundMatch = DoesMatrixContainWord(row - 1, column, index + 1, matrix, targetWord, Direction.Up);
                    break;
                case Direction.Down:
                    foundMatch = DoesMatrixContainWord(row + 1, column, index + 1, matrix, targetWord, Direction.Down);
                    break;
                case Direction.Left:
                    foundMatch = DoesMatrixContainWord(row, column - 1, index + 1, matrix, targetWord, Direction.Left);
                    break;
                case Direction.Right:
                    foundMatch = DoesMatrixContainWord(row, column + 1, index + 1, matrix, targetWord, Direction.Right);
                    break;
            }
            
            return foundMatch;
        }

        public enum Direction
        {
            Up, Down, Left, Right
        }
    }


    [TestFixture]
    class WordSearchTests
    {
        WordSearch _practice = new WordSearch();

        [TestCase("bbbbb", true)]
        [TestCase("derek", true)]
        [TestCase("eecba", true)]
        [TestCase("deeee", true)]
        [TestCase("abcee", true)]
        [TestCase("y", false)]
        [TestCase("abcdef", false)]
        [TestCase("uu", false)]
        [TestCase("aq", false)]
        [TestCase("abced", false)]
        public void WordSearch_WithTestCases_ShouldReturnTrue(string targetWord, bool expected)
        {
            char[,] matrix = new char[,]
            {
                {'a',  'b',  'c',  'd',  'e'},
                {'a',  'b',  'c',  'e',  'e'},
                {'a',  'b',  'c',  'r',  'e'},
                {'a',  'b',  'c',  'e',  'e'},
                {'a',  'b',  'c',  'k',  'd'}
            };

            bool result = _practice.IsWordInMatrix(matrix, targetWord);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
