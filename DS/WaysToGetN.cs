using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class WaysToGetN
    {
        Dictionary<int, int> memoizedResults = new Dictionary<int, int>();

        /// <summary>
        /// Ways to get N from 1,3,4
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int WaysToGetN_DC(int n)
        {
            //Base Case
            if (n <= 2)
            {
                return 1;
            }
            if (n == 3)//{1,1,1} , {3}
            {
                return 2;
            }
            if (n == 4)//{1,3}, {1,1,1,1} {3,1} {4}
            {
                return 4;
            }

            //Recursion
            int ways1 = WaysToGetN_DC(n - 1);
            int ways3 = WaysToGetN_DC(n - 3);
            int ways4 = WaysToGetN_DC(n - 4);

            return ways1 + ways3 + ways4;

        }

        public int WaysToGetN_DP_TopDown(int n)
        {
            //Check if already calculated 
            if (memoizedResults.ContainsKey(n))
            {
                return memoizedResults[n];
            }
            //Base Case
            if (n <= 2)
            {
                memoizedResults.Add(n, 1);
                return 1;
            }
            if (n == 3)//{1,1,1} , {3}
            {
                memoizedResults.Add(n, 2);
                return 2;
            }
            if (n == 4)//{1,3}, {1,1,1,1} {3,1} {4}
            {
                memoizedResults.Add(n, 4);
                return 4;
            }

            //Recursion
            int ways1 = WaysToGetN_DP_TopDown(n - 1);
            int ways3 = WaysToGetN_DP_TopDown(n - 3);
            int ways4 = WaysToGetN_DP_TopDown(n - 4);

            int totalWays = ways1 + ways3 + ways4;

            memoizedResults.Add(n, totalWays);

            return totalWays;

        }
        public int WaysToGetN_DP_BottomUp(int n)
        {
            int[] values = new int[n + 1];
            if (n <= 2)
            {
                return 1;
            }
            if (n == 3)
            {
                return 2;
            }

            values[0] = 1;
            values[1] = 1;
            values[2] = 1;
            values[3] = 2;

            for (int i = 4; i < n + 1; i++)
            {
                values[i] = values[i - 1] + values[i - 3] + values[i - 4];
            }
            return values[n];
        }

    }

}


