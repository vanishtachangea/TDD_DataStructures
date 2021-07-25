using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{

    public class MinCostDPAlgorithm
    {

        public int MinCostClimbingStairs(int[] cost)
        {
            Dictionary<int, int> dpMemory = new Dictionary<int, int>();
            return MinCostDP(cost, cost.Length, dpMemory);
        }
        private int MinCostDP(int[] cost, int i, Dictionary<int, int> dpMemory)
        {
            if (i <= 1)
            {
                return cost[i];
            }
            if (dpMemory.ContainsKey(i))
            {
                return dpMemory[i];
            }
            if (i == cost.Length)
            {
                dpMemory[i] = Math.Min(MinCostDP(cost, i - 1, dpMemory), MinCostDP(cost, i - 2, dpMemory));
                return dpMemory[i];
            }
            else
            {
                dpMemory[i] = cost[i] + Math.Min(MinCostDP(cost, i - 1, dpMemory), MinCostDP(cost, i - 2, dpMemory));
                return dpMemory[i];
            }
        }
        public int MinCostClimbingStairsBottomUp(int[] cost)
        {
            
            return MinCostDPBottomUp(cost);
        }
        private int MinCostDPBottomUp(int[] cost)
        {
            Dictionary<int, int> dpMemory = new Dictionary<int, int>();
            int minCost = cost[0];
            int i = 0;
            for (i = 0; i < cost.Length; i++)
            {
                if (i == 0)
                {
                    minCost = cost[0];
                }
                else if (i == 1)
                {
                    minCost = cost[1];
                }
                else
                {
                    minCost = cost[i] + Math.Min(dpMemory[i - 1], dpMemory[i - 2]);
                }
                dpMemory[i] = minCost;
            }
            dpMemory[i] = Math.Min(dpMemory[i-1], dpMemory[i - 2]);

            return dpMemory[i];
        }
        public int MinCostClimbingStairsBottomUpOptimised(int[] cost)
        {
            return MinCostDPBottomUpOptimised(cost);
        }
        private int MinCostDPBottomUpOptimised(int[] cost)
        {
            int minCostPrev = -1;
            int minCostPrevPrevious = -1;
            for (int i = 0; i < cost.Length; i++)
            {
                if (i == 0)
                {
                    minCostPrevPrevious = cost[0];
                }
                else if (i == 1)
                {
                    minCostPrev = cost[1];
                }
                else
                {
                    int newMinCostPrev = cost[i] + Math.Min(minCostPrev, minCostPrevPrevious);
                    minCostPrevPrevious = minCostPrev;
                    minCostPrev = newMinCostPrev;
                }

            }
            return Math.Min(minCostPrev, minCostPrevPrevious);
        }
    }
}
