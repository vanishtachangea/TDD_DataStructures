using System;

namespace DS
{
    public class CoinChangeSolution
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (coins.Length == 0)
            {
                return 0;
            }
            if (amount == 0)
            {
                return 0;
            }
            Array.Sort(coins);


            int countCoins = 0;

            countCoins = this.CalculateCoins(coins, coins.Length - 1, amount);
            return countCoins;
        }
        public int CalculateCoins(int[] coins, int position, int amount)
        {
            int countCoins = 0;
            int amtRemaining = amount;

            if (position < 0)
            {
                return -1;
            }
            int i = position;
            while (i >= 0 || amtRemaining > 0)
            {
                int biggestDenominator = (int)Math.Floor(amtRemaining / (coins[i] * 1.0));
                if (biggestDenominator > 0)
                {
                    amtRemaining -= (biggestDenominator * coins[i]);
                    countCoins += biggestDenominator;
                }
                i--;
            }
            if (amtRemaining > 0)
            {
                countCoins = CalculateCoins(coins, position - 1, amount);
            }
            return countCoins;

        }


    }


}
