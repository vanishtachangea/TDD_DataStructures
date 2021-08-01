using System;

namespace DS
{
    public class TrappingWater : ITrappingWater
    {
        //https://leetcode.com/problems/trapping-rain-water/submissions/
        public int Trap(int[] height)
        {
            int totalAmount = 0;
            int len = height.Length;
            int maxHeightLeft =0;
            int maxHeightRight= 0;

            int leftPointer = 0;
            int rightPointer = len - 1;
            while(leftPointer <rightPointer)
            {
                //Is height of Left Pointer less than Right Pointer. Choose the Pointer with Lesser Height
                if(height[leftPointer]<=height[rightPointer])
                {
                    //Check whether the height of this Pointer of the Max on that Side
                    if(height[leftPointer]<=maxHeightLeft)
                    {
                        //Calculate Water
                        totalAmount += CalculateAmountOfWater(maxHeightLeft, height[leftPointer]);
                    }
                    else
                    {
                        //Update the Max with the current Height because current Height is higher
                        maxHeightLeft = height[leftPointer];
                        
                    }
                    leftPointer++;
                }
                else
                {
                    if (height[rightPointer] <= maxHeightRight)
                    {
                        //Calculate Water
                        totalAmount += CalculateAmountOfWater(maxHeightRight, height[rightPointer]);
                    }
                    else
                    {
                        maxHeightRight = height[rightPointer];
                        
                    }
                    rightPointer--;
                }
            }


            return totalAmount;
        }
        private int CalculateAmountOfWater(int maxHeight, int currentHeight)
        {
            int currentHeightAtPosition = maxHeight- currentHeight;
            if (currentHeightAtPosition > 0)
                return currentHeightAtPosition;
            else return 0;
        }
        /// <summary>
        /// T=O(N2)
        /// S=O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int TrapBruteForce(int[] height)
        {
            int totalAmount = 0;
            int maxHeightLeft = 0;
            int maxHeightRight = 0;
            int currentHeightAtPosition = 0;
            int len = height.Length;
            for (int i = 0; i < len; i++)
            {
                maxHeightLeft = 0;
                maxHeightRight = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    maxHeightLeft = Math.Max(maxHeightLeft, height[j]);
                }
                for (int j = i + 1; j < len; j++)
                {
                    maxHeightRight = Math.Max(height[j], maxHeightRight);
                }
                currentHeightAtPosition = Math.Min(maxHeightLeft, maxHeightRight) - height[i];
                if (currentHeightAtPosition > 0)
                    totalAmount += currentHeightAtPosition;
            }

            return totalAmount;
        }
    }
}
