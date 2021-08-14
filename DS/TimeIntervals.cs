using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS
{
    public class TimeIntervals
    {
        public bool IsOverlapping(int a, int b, int c, int d)
        {
            if (c <= b && a <= d)
            {
                return true;
            }
            return false;
        }

        public int[][] GetOverallMergedIntervals(int[][] intervals)
        {
            List<int[]> result = new List<int[]>();
            if (intervals.GetLength(0) <= 1)
            {
                return intervals;
            }

            int[] firstInterval = intervals[0];
            int[] secondInterval = new int[2];
            int[] resultInterval = new int[2];
            for (int i = 1; i < intervals.GetLength(0); i++)
            {
                secondInterval = intervals[i];
                resultInterval = new int[2];
                if (IsOverlapping(firstInterval[0], firstInterval[1], secondInterval[0], secondInterval[1]) == true)
                {
                    resultInterval[0] = Math.Min(secondInterval[0], firstInterval[0]);
                    resultInterval[1] = Math.Max(secondInterval[1], firstInterval[1]);


                    if (i == intervals.GetLength(0) - 1)
                    {
                        result.Add(resultInterval);
                    }
                    else
                    {
                        firstInterval = resultInterval;
                    }
                }
                else
                {
                    if (secondInterval[0] < firstInterval[1])
                    {
                        int[] temp = secondInterval;
                        secondInterval = firstInterval;
                        firstInterval = temp;
                    }

                    result.Add(firstInterval);

                    if (i == intervals.GetLength(0) - 1)
                    {
                        result.Add(secondInterval);
                    }
                    else
                    {
                        firstInterval = secondInterval;
                    }
                }

            }

            return result.ToArray();
        }


    }

}
