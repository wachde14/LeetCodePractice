using NUnit.Framework;
using System;

namespace Easy_and_Medium_Questions
{
    /// <summary>
    /// You are given an array prices where prices[i] is the price of a given stock on the ith day.
    /// You want to maximize your profit by choosing a single day to buy one stock and choosing a different day
    /// in the future to sell that stock.
    /// Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
    /// </summary>
    public class BestTimeToBuyAndSellStock
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length <= 1)
            {
                return 0;
            }

            int profit = 0;
            int lowestBuyPrice = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                int currentSellPrice = prices[i];
                if (currentSellPrice > lowestBuyPrice)
                {
                    profit = Math.Max(profit, currentSellPrice - lowestBuyPrice);
                }
                else
                {
                    lowestBuyPrice = currentSellPrice;
                }
            }

            return profit;
        }
    }

    [TestFixture]
    class BestTimeToBuyAndSellStockTests
    {
        readonly BestTimeToBuyAndSellStock _practice = new BestTimeToBuyAndSellStock();

        [TestCase(new int[] { 2, 4, 1 }, 2)]
        [TestCase(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
        [TestCase(new int[] { 7, 6, 4, 3, 1 }, 0)]
        [TestCase(new int[] { 3, }, 0)]
        public void MaxProfit_WithTestCases_ShouldReturnExpected(int[] prices, int expected)
        {
            int result = _practice.MaxProfit(prices);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}
