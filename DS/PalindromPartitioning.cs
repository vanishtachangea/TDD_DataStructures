using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DS
{
    public class PalindromPartitioning
    {
        int CountCuts = 0;

        public int MinCut(string s)
        {
            //CountCuts = s.Length - 1;
            //if (s.Length == 1)
            //{
            //    CountCuts = 0;
            //}
            //else CountCuts = MinCutBacktrack(s, 0, s.Length-1);
            //return CountCuts;
            return MinCutBacktrack(s, 0, s.Length - 1);
        }

        public int MinCutBacktrack(string s, int start, int end)
        {
            if (start == end || IsPalindrome(s, start, end))
            {
                return 0;
            }
            for (int i = start; i <= end; i++)
            {
                if (IsPalindrome(s, start, i))
                {
                    CountCuts = Math.Min(CountCuts, 1 + MinCutBacktrack(s, i + 1, end));
                }
            }      
            return CountCuts;            
        }

        public bool IsPalindrome(string s, int start, int end)
        {
            s = s.Substring(start, end - start + 1);
            s = CleanString(s);

            int i = 0;
            int j = s.Length-1;
            while (j >= i)
            {
                if (s[i] != s[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }

        private string CleanString(string s)
        {

            s = s.Replace(" ", "");
            s = Regex.Replace(s, "[^a-zA-Z0-9]", String.Empty);
            s = s.ToLower();
            return s;
        }
    }
}
