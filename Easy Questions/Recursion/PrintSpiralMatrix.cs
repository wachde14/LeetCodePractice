using NUnit.Framework;

namespace Easy_and_Medium_Questions
{
    public class PrintSpiralMatrix
    {
        public int[] PrintSpiralMatrixIterative(int[,] inputMatrix)
        {
            int height = inputMatrix.GetLength(0);
            int length = inputMatrix.GetLength(1);
            int totalSize = length * height;

            int processedCount = 0;
            int[] result = new int[totalSize];

            int currRow = 0;
            int currColumn = 0;

            int leftColumnBound = -1;
            int rightColumnBound = length;
            int upperRowBound = 0;
            int lowerRowBound = height - 1;


            while (processedCount < totalSize)
            {
                //left to right
                while (currColumn < rightColumnBound)
                {
                    result[processedCount] = inputMatrix[currRow, currColumn];
                    processedCount++;  
                    currColumn++;
                }
                currColumn--;
                rightColumnBound--;
                currRow++;

                if (processedCount == totalSize)
                    return result;

                //top to bottom, excluding current top currRow and current bottom currRow
                while (currRow < lowerRowBound)
                {
                    result[processedCount] = inputMatrix[currRow, currColumn];
                    processedCount++;
                    currRow++;
                }
                lowerRowBound--;

                if (processedCount == totalSize)
                    return result;

                //right to left
                while (currColumn > leftColumnBound)
                {
                    result[processedCount] = inputMatrix[currRow, currColumn];
                    processedCount++;
                    currColumn--;
                }
                currColumn++;
                currRow--;
                leftColumnBound++;

                if (processedCount == totalSize)
                    return result;

                //bottom to top, excluding top currRow and current bottom currRow
                while (currRow > upperRowBound)
                {
                    result[processedCount] = inputMatrix[currRow, currColumn];
                    processedCount++;
                    currRow--;
                }
                currRow++;
                currColumn++;
                upperRowBound++;

            }

            return result;
        }

        public int[] PrintSpiralMatrixRecursive(int[,] inputMatrix, int rowStart, int colStart, int colLength, int rowLength, int[] result, int processedCount)
        {
            for (int y = rowStart; y <= rowLength; y++)
            {
                result[processedCount] = inputMatrix[rowStart, y];
                processedCount++;
            }
            if (processedCount == result.GetLength(0))
            {
                return result;
            }

            for (int i = colStart + 1; i <= colLength - 1; i++)
            {
                result[processedCount] = inputMatrix[i, rowLength];
                processedCount++;
            }
            if (processedCount == result.GetLength(0))
            {
                return result;
            }


            for (int y = rowLength; y >= colStart; y--)
            {
                result[processedCount] = inputMatrix[colLength, y];
                processedCount++;
            }
            if (processedCount == result.GetLength(0))
            {
                return result;
            }


            for (int i = colLength - 1; i >= rowStart + 1; i--)
            {
                result[processedCount] = inputMatrix[i, colStart];
                processedCount++;
            }

            if (processedCount < result.GetLength(0))
            {
                PrintSpiralMatrixRecursive(inputMatrix, ++rowStart, ++colStart, --colLength, --rowLength, result, processedCount);
            }

            return result;
        }

    }

    [TestFixture]
    class PrintSpiralMatrixRecursiveTests
    {
        PrintSpiralMatrix printSpiralMatrix = new PrintSpiralMatrix();

        [Test]
        public void PrintSpiralMatrix_WithValidSquareMatrix3x3_ShouldReturnExpected()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[,] input = new int[,]
            {
                {1, 2, 3},
                {8, 9, 4},
                {7, 6, 5}
            };

            int columnLength = input.GetLength(1);
            int rowLength = input.GetLength(0);
            int[] result = new int[((columnLength) * (rowLength))];
            int processedCount = 0;

            result = printSpiralMatrix.PrintSpiralMatrixRecursive(input, 0, 0, columnLength - 1, rowLength - 1, result, processedCount);

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void PrintSpiralMatrix_WithValidSquareMatrix4x4_ShouldReturnExpected()
        {

            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            int[,] input = new int[,]
            {
                {1,  2,  3,  4},
                {12, 13, 14, 5},
                {11, 16, 15, 6},
                {10, 9,  8,  7},

            };

            int columnLength = input.GetLength(1);
            int rowLength = input.GetLength(0);
            int[] result = new int[((columnLength) * (rowLength))];
            int processedCount = 0;

            result = printSpiralMatrix.PrintSpiralMatrixRecursive(input, 0, 0, columnLength - 1, rowLength - 1, result, processedCount);

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void PrintSpiralMatrix_WithValidSquareMatrix5x5_ShouldReturnExpected()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };

            int[,] input = new int[,]
            {
                {1,  2,  3,  4,  5},
                {16, 17, 18, 19, 6},
                {15, 24, 25, 20, 7},
                {14, 23, 22, 21, 8},
                {13, 12, 11, 10, 9},
            };

            int columnLength = input.GetLength(1);
            int rowLength = input.GetLength(0);
            int[] result = new int[((columnLength) * (rowLength))];
            int processedCount = 0;

            result = printSpiralMatrix.PrintSpiralMatrixRecursive(input, 0, 0, columnLength - 1, rowLength - 1, result, processedCount);

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void PrintSpiralMatrix_WithValidSquareMatrix4x2_ShouldReturnExpected()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            int[,] input = new int[,]
            {
                {1, 2},
                {8, 3},
                {7, 4},
                {6, 5}
            };

            int columnLength = input.GetLength(0);
            int rowLength = input.GetLength(1);
            int[] result = new int[((columnLength) * (rowLength))];
            int processedCount = 0;

            result = printSpiralMatrix.PrintSpiralMatrixRecursive(input, 0, 0, columnLength - 1, rowLength - 1, result, processedCount);

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void PrintSpiralMatrix_WithValidSquareMatrix2x5_ShouldReturnExpected()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[,] input = new int[,]
            {
                {1,  2, 3, 4, 5},
                {10, 9, 8, 7, 6},
            };

            int columnLength = input.GetLength(0);
            int rowLength = input.GetLength(1);
            int[] result = new int[((columnLength) * (rowLength))];
            int processedCount = 0;

            result = printSpiralMatrix.PrintSpiralMatrixRecursive(input, 0, 0, columnLength - 1, rowLength - 1, result, processedCount);

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void PrintSpiralMatrix_WithValidSquareMatrix2x4_ShouldReturnExpected()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

            int[,] input = new int[,]
            {
                {1,  2,  3,  4},
                {10, 11, 12, 5},
                {9,  8,  7,  6},
            };

            int columnLength = input.GetLength(0);
            int rowLength = input.GetLength(1);
            int[] result = new int[((columnLength) * (rowLength))];
            int processedCount = 0;

            result = printSpiralMatrix.PrintSpiralMatrixRecursive(input, 0, 0, columnLength - 1, rowLength - 1, result, processedCount);

            Assert.That(expected, Is.EqualTo(result));
        }


    }

    [TestFixture]
    class PrintSpiralMatrixIterativeTests
    {
        PrintSpiralMatrix printSpiralMatrix = new PrintSpiralMatrix();

        [Test]
        public void PrintSpiralMatrix_WithValidSquareMatrix3x3_ShouldReturnExpected()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[,] input = new int[,]
            {
                {1, 2, 3},
                {8, 9, 4},
                {7, 6, 5}
            };

            int[] result = printSpiralMatrix.PrintSpiralMatrixIterative(input);

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void PrintSpiralMatrix_WithValidSquareMatrix4x4_ShouldReturnExpected()
        {

            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            int[,] input = new int[,]
            {
                {1,  2,  3,  4},
                {12, 13, 14, 5},
                {11, 16, 15, 6},
                {10, 9,  8,  7},

            };

            int[] result = printSpiralMatrix.PrintSpiralMatrixIterative(input);

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void PrintSpiralMatrix_WithValidSquareMatrix5x5_ShouldReturnExpected()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };

            int[,] input = new int[,]
            {
                {1,  2,  3,  4,  5},
                {16, 17, 18, 19, 6},
                {15, 24, 25, 20, 7},
                {14, 23, 22, 21, 8},
                {13, 12, 11, 10, 9},
            };

            int[] result = printSpiralMatrix.PrintSpiralMatrixIterative(input);

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void PrintSpiralMatrix_WithValidSquareMatrix4x2_ShouldReturnExpected()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            int[,] input = new int[,]
            {
                {1, 2},
                {8, 3},
                {7, 4},
                {6, 5}
            };

            int[] result = printSpiralMatrix.PrintSpiralMatrixIterative(input);

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void PrintSpiralMatrix_WithValidSquareMatrix2x5_ShouldReturnExpected()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[,] input = new int[,]
            {
                {1,  2, 3, 4, 5},
                {10, 9, 8, 7, 6},
            };

            int[] result = printSpiralMatrix.PrintSpiralMatrixIterative(input);

            Assert.That(expected, Is.EqualTo(result));
        }

    }
}
