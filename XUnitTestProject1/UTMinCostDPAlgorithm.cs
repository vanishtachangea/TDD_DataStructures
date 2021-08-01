using System;
using System.Collections;
using Xunit;
using DS;
using System.Collections.Generic;

namespace XUnitTestDataStructuresAlgorithms
{
    /// <summary>
    /// https://leetcode.com/problems/min-cost-climbing-stairs/
    /// </summary>
    public class UTMinCostDPAlgorithm
    {
        [Fact]
        public void ReturnGooAnswerFromRecursiveDP()
        {
            MinCostDPAlgorithm minCostDPAlgorithm = new MinCostDPAlgorithm();
            int[] cost = { 10, 15, 20 };
            int minCost = minCostDPAlgorithm.MinCostClimbingStairs(cost);

            Assert.Equal(15, minCost);

        }

        [Fact]
        public void ReturnGooAnswerFromDPBottomUp()
        {
            MinCostDPAlgorithm minCostDPAlgorithm = new MinCostDPAlgorithm();
            int[] cost = { 10, 15, 20 };
            int minCost = minCostDPAlgorithm.MinCostClimbingStairsBottomUp(cost);

            Assert.Equal(15, minCost);

        }

        [Fact]
        public void MinCostClimbingStairsBottomUpOptimised()
        {
            MinCostDPAlgorithm minCostDPAlgorithm = new MinCostDPAlgorithm();
            int[] cost = { 10, 15, 20 };
            int minCost = minCostDPAlgorithm.MinCostClimbingStairsBottomUpOptimised(cost);

            Assert.Equal(15, minCost);

        }



    }

}
