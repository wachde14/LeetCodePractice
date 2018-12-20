using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Medium_Questions
{
    /// <summary>
    /// A number is a colorful rainbow color if the product of the powerset of its
    /// digits are all unique.
    /// </summary>
    class ColorfulRainbowNumbers
    {
        public bool IsColorfulRainbowNum(int[] a)
        {
            Dictionary<int, int> productFreqDict = new Dictionary<int, int>();

            var results = GetAllProducts(a.ToList(), 0);

            HashSet<int> productSet = new HashSet<int>();
            foreach(List<int> set in results)
            {
                if (set.Count == 0)
                {
                    continue;
                }

                int product = 1;
                foreach (int value in set)
                {
                    product *= value;
                }
                if (productSet.Contains(product))
                {
                    return false;
                }
                productSet.Add(product);

            }

            return true;
        }

        public List<List<int>> GetAllProducts(List<int> a, int index)
        {
            List<List<int>> allSubSets;
            if (index == a.Count)
            {
                allSubSets = new List<List<int>>();
                allSubSets.Add(new List<int>());
            }
            else
            {
                allSubSets = GetAllProducts(a, index + 1);
                int item = a[index];

                List<List<int>> moreSubSets = new List<List<int>>();
                foreach (List<int> subset in allSubSets)
                {
                    List<int> newSubSet = new List<int>();
                    newSubSet.AddRange(subset);
                    newSubSet.Add(item);
                    moreSubSets.Add(newSubSet);
                }
                allSubSets.AddRange(moreSubSets);

            }

            return allSubSets;
        }
    }

    [TestFixture]
    class ColorfulRainbowNumbersTests
    {
        ColorfulRainbowNumbers _practice = new ColorfulRainbowNumbers();

        [Test]
        public void ColorfulNumbers_WithRainbowArray_ShouldReturnTrue()
        {
            int[] a = { 3, 5, 4, 2 };

            bool result = _practice.IsColorfulRainbowNum(a);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void ColorfulNumbers_WithNonRainbowArray_ShouldReturnFalse()
        {
            int[] a = { 2, 6, 3 };

            bool result = _practice.IsColorfulRainbowNum(a);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void ColorfulNumbers_WithNonRainbowArray2_ShouldReturnFalse()
        {
            int[] a = { 2, 3, 6 };

            bool result = _practice.IsColorfulRainbowNum(a);

            Assert.AreEqual(false, result);
        }
    }
}
