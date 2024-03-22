using NUnit.Framework;
using System.Collections.Generic;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// Determine whether a number is colorful or not. 263 is a colorful number
    /// because (2,6,3,2x6,6x3,2x3x6) are all different whereas 236 is not because
    /// (2,3,6,2x3,3x6,2x3x6) have 6 twice. So take all consecutive subsets of digits, 
    /// take their product and ensure all the products are different
    /// </summary>
    class ColorfulNumbers
    {
        public bool IsColorfulNum(int[] a)
        {
            HashSet<int> productSet = new HashSet<int>();

            for (int i = 0; i < a.Length; i++)
            {
                int product = 1;

                for (int j = i; j < a.Length; j++)
                {
                    product *= a[j];
                    if (productSet.Contains(product))
                    {
                        return false;
                    }

                    productSet.Add(product);
                }
            }
            return true;
        }
    }


    [TestFixture]
    class ColorfulNumbersTests
    {
        ColorfulNumbers _practice = new ColorfulNumbers();

        [Test]
        public void ColorfulNumbers_WithColorfulArray_ShouldReturnTrue()
        {
            int[] a = { 3, 5, 4, 2 };

            bool result = _practice.IsColorfulNum(a);

            Assert.That(result);
        }

        [Test]
        public void ColorfulNumbers_WithColorfulArray2_ShouldReturnTrue()
        {
            int[] a = { 2, 6, 3 };

            bool result = _practice.IsColorfulNum(a);

            Assert.That(result);
        }

        [Test]
        public void ColorfulNumbers_WithNonColorfulArray_ShouldReturnFalse()
        {
            int[] a = { 2, 3, 6 };

            bool result = _practice.IsColorfulNum(a);

            Assert.That(!result);
        }
    }
}

