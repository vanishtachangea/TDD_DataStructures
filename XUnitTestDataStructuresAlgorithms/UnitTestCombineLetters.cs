using System;
using System.Collections;
using Xunit;
using DS;
using System.Collections.Generic;

namespace XUnitTestDataStructuresAlgorithms
{
    public class UnitTestCombineLetters
    {
        [Theory]
        [InlineData("2", new string[] { "a", "b", "c" })]
        [InlineData("", new string[] { })]
        //[InlineData("23", new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
        public void ReturnBasic(string input, string[] expected)
        {
            HashTableCustom customHashTable = new HashTableCustom();

            //Case 1 
            List<string> actual = (List<String>)customHashTable.LetterCombinations(input);
            Assert.Equal(actual, expected);

            //Case 2
            //customHashTable = new HashTableCustom();
            //string input2 = "23";
            //List<string> actual2 = (List<String>)customHashTable.LetterCombinations(input2);
            //string[] expected2 = new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };
            //Assert.Equal(actual2, expected2);
        }
        [Fact]
        public void CanCombineLettersSuccessfully()
        {
            HashTableCustom customHashTable = new HashTableCustom();

            //Case 1 
            string input = "23";
            string[] expected = new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };
            List<string> actual = (List<String>)customHashTable.LetterCombinations(input);
            Assert.Equal(actual, expected);

            //Case 2
            //customHashTable = new HashTableCustom();
            //string input2 = "23";
            //List<string> actual2 = (List<String>)customHashTable.LetterCombinations(input2);
            //string[] expected2 = new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };
            //Assert.Equal(actual2, expected2);
        }

}

}
