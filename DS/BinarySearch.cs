using System;

namespace DS
{
    public class BinarySearch : IBinarySearch
    {
        private int targetTempStartPointer { get; set; }
        private int targetTempEndPointer { get; set; }
        private int targetTempPointer { get; set; }
        //T=O(LogN), S=O(1)
        public int Search(int[] array, int valueToSearch)
        {
            int leftPointer = 0;
            int rightPointer = array.Length - 1;
            int pointer = -1;

            while (leftPointer <= rightPointer)
            {
                pointer = (int)Math.Floor((leftPointer + rightPointer) / 2.0);
                if (array[pointer] == valueToSearch)
                {
                    return pointer;
                }
                else if (valueToSearch > array[pointer])
                {
                    leftPointer = pointer + 1;
                }
                else
                {
                    rightPointer = pointer - 1;
                }
            }
            return -1;

        }
        public int[] SearchRange(int[] nums, int target)
        {
            System.Diagnostics.Debug.WriteLine("Matrix has you...");
            targetTempStartPointer = -1;
            targetTempEndPointer = -1;
            targetTempPointer = -1;
            targetTempPointer = SearchRangeRecursive(nums, 0, nums.Length - 1, target);
            targetTempStartPointer = targetTempPointer;
            targetTempEndPointer = targetTempPointer;
            while (targetTempStartPointer > -1)
            {
                targetTempPointer = targetTempStartPointer;
                targetTempStartPointer = SearchRangeRecursive(nums, 0, targetTempPointer - 1, target);
            }
            targetTempStartPointer = targetTempPointer;
            while (targetTempEndPointer > -1)
            {
                targetTempPointer = targetTempEndPointer;
                targetTempEndPointer = SearchRangeRecursive(nums, targetTempPointer + 1, nums.Length - 1, target);
            }
            targetTempEndPointer = targetTempPointer;
            return new int[] { targetTempStartPointer, targetTempEndPointer };

        }
        public int SearchRangeRecursive(int[] nums, int leftPointer, int rightPointer, int target)
        {
            int pointer = -1;

            while (leftPointer <= rightPointer)
            {
                pointer = (int)Math.Floor((leftPointer + rightPointer) / 2.0);
                if (nums[pointer] == target)
                {

                    return pointer;

                }
                else if (target > nums[pointer])
                {
                    leftPointer = pointer + 1;
                }
                else
                {
                    rightPointer = pointer - 1;
                }
            }
            return -1;
        }
    }
}
