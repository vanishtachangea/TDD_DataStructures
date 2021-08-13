using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class WaysToGetN
    {
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
    }

}
