using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{

    public class SolutionLCS
    {
        public Dictionary<int[], int> memorizeLCS = new Dictionary<int[], int>();
        //public int?[][] DPMemory = new int?[1000][];
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int lenText1 = text1.Length;
            int lenText2 = text2.Length;
            if(lenText1 <=0 || lenText2<=0)
            {
                return 0;
            }
            if(text1.StartsWith(text2.Substring(0,1)))
            {
                return 1 + LongestCommonSubsequence(text1.Substring(1, lenText1 - 1), text2.Substring(1, lenText2 - 1));
            }
            else
            {
                return Math.Max(LongestCommonSubsequence(text1.Substring(1, lenText1 - 1), text2), LongestCommonSubsequence(text1, text2.Substring(1, lenText2 - 1)));
            }
        }
        public int LongestCommonSubsequenceMemoized(string text1, string text2)
        {
            int lenText1 = text1.Length;
            int lenText2 = text2.Length;

            int[] memorizeLCSKeys = new int[2];
            memorizeLCSKeys[0] = lenText1;
            memorizeLCSKeys[1] = lenText2;
            if (memorizeLCS.ContainsKey(memorizeLCSKeys))
            {
                return memorizeLCS[memorizeLCSKeys];
            }
            if (lenText1 <= 0 || lenText2 <= 0)
            {
                memorizeLCSKeys[0] = lenText1;
                memorizeLCSKeys[1] = lenText2;
                memorizeLCS[memorizeLCSKeys] = 0;
                return memorizeLCS[memorizeLCSKeys];
            }
            if (text1.StartsWith(text2.Substring(0, 1)))
            {
                memorizeLCSKeys[0] = lenText1;
                memorizeLCSKeys[1] = lenText2;
                memorizeLCS[memorizeLCSKeys] = 1 + LongestCommonSubsequenceMemoized(text1.Substring(1, lenText1 - 1), text2.Substring(1, lenText2 - 1));

                return memorizeLCS[memorizeLCSKeys];
            }
            else
            {
                memorizeLCSKeys[0] = lenText1;
                memorizeLCSKeys[1] = lenText2;
                memorizeLCS[memorizeLCSKeys] = Math.Max(LongestCommonSubsequenceMemoized(text1.Substring(1, lenText1 - 1), text2), LongestCommonSubsequenceMemoized(text1, text2.Substring(1, lenText2 - 1)));

                return memorizeLCS[memorizeLCSKeys];
            }
        }

        public int LongestCommonSubsequenceMemoized2(string text1, string text2, int?[,] DPMemory)
        {
            int lenText1 = text1.Length;
            int lenText2 = text2.Length;

            if (lenText1 <= 0 || lenText2 <= 0)
            {
                DPMemory[lenText1,lenText2] = 0;
                return (int) DPMemory[lenText1,lenText2];
            }
            if (DPMemory[lenText1,lenText2] != null)
            {
                return (int)DPMemory[lenText1,lenText2];
            }
            if (text1.StartsWith(text2.Substring(0, 1)))
            {

                DPMemory[lenText1,lenText2] = 1 + LongestCommonSubsequenceMemoized2(text1.Substring(1, lenText1 - 1), text2.Substring(1, lenText2 - 1), DPMemory);

                return (int) DPMemory[lenText1,lenText2];
            }
            else
            {
                DPMemory[lenText1,lenText2] = Math.Max(LongestCommonSubsequenceMemoized2(text1.Substring(1, lenText1 - 1), text2, DPMemory), LongestCommonSubsequenceMemoized2(text1, text2.Substring(1, lenText2 - 1), DPMemory));

                return  (int)DPMemory[lenText1,lenText2];
            }
        }

    }
}
