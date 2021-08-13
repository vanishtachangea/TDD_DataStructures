using System;

namespace DS
{
    public class StringManipulation
    {
        private const char OpeningBracket = '[';
        private const char ClosingBracket = ']';
        private string decompressedResult = String.Empty;

        public string Decompress(string compressedString)
        {
            int i = 0;
            decompressedResult = String.Empty;

            string stringToRepeat = String.Empty;
            while (i < compressedString.Length)
            {
                if (!Char.IsDigit(compressedString, i))
                {
                    decompressedResult += compressedString[i];
                    i++;
                    continue;
                }
                string number = String.Empty;
                while (Char.IsDigit(compressedString, i))
                {
                    number += compressedString[i];
                    i++;
                }
                int numberOfReps = Int32.Parse(number);
                if (compressedString[i] != OpeningBracket)
                {
                    return String.Empty;
                }
                int countOpenBrackets = 1;
                int countClosingBrackets = 0;
                stringToRepeat = String.Empty;
                while (countClosingBrackets < countOpenBrackets)
                {
                    i++;

                    if (compressedString[i] == OpeningBracket)
                    {
                        countOpenBrackets++;
                    }
                    else if (compressedString[i] == ClosingBracket)
                    {
                        countClosingBrackets++;
                    }
                    stringToRepeat += compressedString[i];
                }
                if (countClosingBrackets == countOpenBrackets)
                {
                    stringToRepeat = stringToRepeat.Remove(stringToRepeat.Length - 1, 1);
                    string repeatedText = DecompressRecursive(stringToRepeat, numberOfReps);
                    decompressedResult += Decompress(repeatedText);
                }

                i++;
            }
            return decompressedResult;

        }




        public string DecompressRecursive(string textToRepeat, int numberOfReps)
        {
            if (numberOfReps == 1)
            {
                return textToRepeat;
            }
            return string.Concat(textToRepeat, DecompressRecursive(textToRepeat, numberOfReps - 1));

        }
    }

}
