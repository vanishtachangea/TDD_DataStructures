using System.Collections.Generic;

namespace DS
{
    public class FibonacciSolution
    {
        public int Fib(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            int[] results = new int[n + 1];
            results[0] = 0;
            results[1] = 1;
            for (int i = 2; i < n + 1; i++)
            {
                results[i] = results[i - 1] + results[i - 2];
            }
            return results[n];

        }
    }

}
