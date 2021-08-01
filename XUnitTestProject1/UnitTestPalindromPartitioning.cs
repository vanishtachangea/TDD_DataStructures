using System;
using System.Collections;
using Xunit;
using DS;
using System.Collections.Generic;

namespace XUnitTestDataStructuresAlgorithms
{
    public class UnitTestPalindromPartitioning
    {

        [Fact]
        public void TestOne()
        {

            PalindromPartitioning palindromPartitioning = new PalindromPartitioning();
            int actualResult =  palindromPartitioning.MinCut("aab");
            Assert.Equal(1, actualResult);
            actualResult = palindromPartitioning.MinCut("a");
            Assert.Equal(0, actualResult);
        }
        [Fact]
        public void Test2()
        {

            PalindromPartitioning palindromPartitioning = new PalindromPartitioning();
            int actualResult = palindromPartitioning.MinCut("a");
            Assert.Equal(0, actualResult);
        }
        [Fact]
        public void Test3()
        {

            PalindromPartitioning palindromPartitioning = new PalindromPartitioning();
            int actualResult = palindromPartitioning.MinCut("aaabbbccd");
            Assert.Equal(2, actualResult);
        }

    }

}
