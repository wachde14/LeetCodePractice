using NUnit.Framework;

namespace Easy_Questions
{
    public class SpecialPositionsInMatrix
    {
        public int NumSpecial(int[,] mat)
        {
            int width = mat.GetLength(0);
            int height = mat.GetLength(1);
            int specialCount = 0;

            for(int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (mat[i,j] == 1 && isSpecial(mat, i, j))
                    {
                        specialCount++;
                        break;
                    }
                }
            }

            return specialCount;
        }

        private bool isSpecial(int[,] mat, int rowNumber, int colNumber)
        {
            int width = mat.GetLength(0);
            int height = mat.GetLength(1);

            int oneCount = 0;

            for (int i = 0; i < width; i++)
            {
                if (mat[rowNumber, i] == 1)
                {
                    oneCount++;
                }
            }


            for (int i = 0; i < height; i++)
            {
                if (mat[i, colNumber] == 1)
                {
                    oneCount++;
                }
            }

            return oneCount == 2;
        }
    }

    [TestFixture]
    class SpecialPositionsInMatrixTests
    {
        SpecialPositionsInMatrix _practice = new SpecialPositionsInMatrix();

        [Test]
        public void SpecialPositionsInMatrix_With1Special3x3_ShouldReturn1()
        {
            int[,] input = new int[,] 
            { 
                { 1, 0, 0 }, 
                { 0, 0, 1 },
                { 1, 0, 0 },
            };

            Assert.AreEqual(1, _practice.NumSpecial(input));
        }

        [Test]
        public void SpecialPositionsInMatrix_With3Specials3x3_ShouldReturn3()
        {
            int[,] input = new int[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 },
            };

            Assert.AreEqual(3, _practice.NumSpecial(input));
        }

        [Test]
        public void SpecialPositionsInMatrix_With2Specials4x4_ShouldReturn2()
        {
            int[,] input = new int[,]
            {
                { 0, 0, 0, 1 },
                { 1, 0, 0, 0 },
                { 0, 1, 1, 0 },
                { 0, 0, 0, 0 },
            };

            Assert.AreEqual(2, _practice.NumSpecial(input));
        }

        [Test]
        public void SpecialPositionsInMatrix_With3Specials5x5_ShouldReturn3()
        {
            int[,] input = new int[,]
            {
                {0,0,0,0,0 },
                {1,0,0,0,0 },
                {0,1,0,0,0 },
                {0,0,1,0,0 },
                {0,0,0,1,1 },

            };

            Assert.AreEqual(3, _practice.NumSpecial(input));
        }
    }
}
