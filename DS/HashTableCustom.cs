using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DS
{
    public class HashTableCustom
    {
        private int digitInt;

        public Dictionary<string, string[]> Mapping { get; set; }
        public List<string> CombinedList { get; set; }
        public string[][] StringArrays { get; set; }
        private string TempList { get; set; }
        public HashTableCustom()
        {
            Mapping = new Dictionary<string, string[]>
            {
                { "0", new string[] { } },
                { "1", new string[] { } },
                { "2", new string[] { "a", "b", "c" } },
                { "3", new string[] { "d", "e", "f" } },
                { "4", new string[] { "g", "h", "i" } },
                { "5", new string[] { "j", "k", "l" } },
                { "6", new string[] { "m", "n", "o" } },
                { "7", new string[] { "p", "q", "r", "s" } },
                { "8", new string[] { "t", "u", "v" } },
                { "9", new string[] { "w", "x", "y", "z" } }
            };

            CombinedList = new List<string>();
            TempList = "";
        }
        public IList<string> LetterCombinations(string digits)
        {
            CombinedList = new List<string>();
            TempList = "";
            if (digits == "")
            {
                return CombinedList;
            }
            else if (!IsValidStrings(digits))
            {
                return CombinedList;
            }
            else if (digits.Length == 1)
            {
                CombinedList.AddRange(Mapping[digits.Substring(0, 1)]);
            }
            else
            {
                //List<string> l = (List<string>)CombineArrays(mapping[digits.Substring(0, 1)], mapping[digits.Substring(1, 1)]);
                //CombinedList.AddRange(l);
                int tempi = 0;
                int tempj = 0;
                SetArraysBasedOnDigits(digits);
                CombineArraysBackTrack(tempi, tempj, StringArrays, digits);
            }
            Debug.WriteLine("TEst");
            Console.WriteLine("cb", CombinedList);

            return CombinedList;

        }
        /// <summary>
        /// Works
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        private IList<string> CombineArrays(string[] array1, string[] array2)
        {
            List<string> tempList = new List<string>();
            int pointer1 = 0;
            int pointer2 = 0;
            while (pointer1 < array1.Length)
            {
                if (pointer2 >= array2.Length)
                {
                    pointer2 = 0;
                    pointer1++;
                    continue;
                }
                tempList.Add(String.Concat(array1[pointer1], array2[pointer2]));
                pointer2++;
            }
            return tempList;
        }
        private void SetArraysBasedOnDigits(string digits)
        {
            int noOfDigits = digits.Length;
            this.StringArrays = new string[noOfDigits][];
            for (int i = 0; i < noOfDigits; i++)
            {
                this.StringArrays[i] = Mapping[digits.Substring(i, 1)];
            }
        }

        private void CombineArraysBackTrack(int tempi, int tempj, string[][] array1, string digits)
        {
            try
            {


                if (tempi == digits.Length && tempj == array1[tempi].Length)
                {
                    return;
                }
                if (tempj == array1[tempi].Length)
                {
                    tempj = 0;
                    tempi--;
                    if (TempList.Length > 0)
                        TempList = TempList.Substring(0, TempList.Length - 2);
                }
                if (tempi < digits.Length && tempi >= 0 && tempj < array1[0].Length && tempj >= 0)
                {
                    TempList +=(array1[tempi++][tempj]);
                }
                if (TempList.Length == digits.Length)
                {
                    CombinedList.Add(TempList.ToString());
                    TempList = TempList.Substring(0, TempList.Length - 2);
                    CombineArraysBackTrack(--tempi, ++tempj, array1, digits);
                }
                CombineArraysBackTrack(tempi, tempj, array1, digits);
            }
            catch(Exception e)
            {
                Console.WriteLine(string.Concat(e.ToString(), " , ", tempi, tempj));
                return;
            }

        }
        private bool IsValidString(string digit)
        {
            if (!(int.TryParse(digit, out digitInt)))
            {
                return false;
            }
            if (digitInt < 2 || digitInt > 9)
            {
                return false;
            }
            return true;
        }
        private bool IsValidStrings(string digits)
        {
            bool isValid = false;
            for (int i = 0; i < digits.Length; i++)
            {
                isValid = IsValidString(digits.Substring(i, 1));
                if (isValid == false) return isValid;
            }
            return isValid;
        }
    }
}
