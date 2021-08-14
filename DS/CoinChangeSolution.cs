using System;
using System.Collections.Generic;

namespace DS
{

        public class CoinChangeSolution
        {
            Dictionary<int, int> memoizedValues = new Dictionary<int, int>();
            public int CoinChange(int[] coins, int amount)
            {
                if (coins.Length == 0)
                {
                    return 0;
                }
                if (amount <= 0)
                {
                    return 0;
                }
                return CoinChangeDC(coins, amount);
            }
            public int CoinChangeDC(int[] coins, int remainingAmount)
            {
                //Base
                if (remainingAmount < 0)
                {
                    return -1;
                }
                if (remainingAmount == 0)
                {
                    return 0;
                }
                //Add Memoization
                if (memoizedValues.ContainsKey(remainingAmount))
                {
                    return memoizedValues[remainingAmount];
                }
                //Recursion
                int minCoinsCount = Int32.MaxValue;
                for (int i = 0; i < coins.Length; i++)
                {
                    int coinValue = coins[i];
                    int count = CoinChangeDC(coins, remainingAmount - coinValue);
                    if (count >= 0 && count < minCoinsCount)
                    {
                        minCoinsCount = 1 + count;
                    }


                }
                if (minCoinsCount == Int32.MaxValue)
                {
                    minCoinsCount = -1;
                }
                memoizedValues.Add(remainingAmount, minCoinsCount);
                return memoizedValues[remainingAmount];
            }
        }
    


}
