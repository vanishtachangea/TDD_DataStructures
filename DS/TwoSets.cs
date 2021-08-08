using System.Collections.Generic;

namespace DS
{
    /// <summary>
    /// https://leetcode.com/problems/intersection-of-two-arrays/solution/
    /// </summary>
    public class TwoSets
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {


            int nums1Length = nums1.Length;
            int nums2Length = nums2.Length;

            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            for (int i = 0; i < nums1Length; i++)
            {
                set1.Add(nums1[i]);
            }
            for (int i = 0; i < nums2Length; i++)
            {
                set2.Add(nums2[i]);
            }
            if (nums1.Length < nums2.Length)
            {
                set1.IntersectWith(set2);
                return set1.ToArray();
            }
            else
            {
                set2.IntersectWith(set1);
                return set2.ToArray();
            }
            return new int[] { };

        }
    }
}
